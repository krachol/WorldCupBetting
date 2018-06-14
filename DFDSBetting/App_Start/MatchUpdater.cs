using DFDSBetting.Models;
using DFDSBetting.Models.ApiModels;
using FluentScheduler;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace DFDSBetting.App_Start
{
    internal class MatchUpdater : IJob, IRegisteredObject
    {

        private readonly object _lock = new object();

        private bool _shuttingDown;

        public MatchUpdater()
        {
            HostingEnvironment.RegisterObject(this);
        }

        public void Execute()
        {
            try
            {
                lock (_lock)
                {
                    if (_shuttingDown)
                        return;

                    // Do work, son!
            WriteFromAPIAsync().Wait();
                }
            }
            finally
            {
                // Always unregister the job when done.
                HostingEnvironment.UnregisterObject(this);
            }
        }

        static async Task WriteFromAPIAsync()
        {
            await UpdateMatchesAsync();
        }

        private static async Task UpdateMatchesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var uri = new Uri("http://api.football-data.org/v1/competitions/467/fixtures");
                httpClient.BaseAddress = uri;
                httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "af622bfaeb6f460c82c065fa829a804a");
                var response = await httpClient.GetAsync(uri);

                var objResult = JsonConvert.DeserializeObject<APIFixtures>(await response.Content.ReadAsStringAsync());

                using (var _context = new ApplicationDbContext())
                {
                    foreach (var matchTeamNames in await _context.Matches.Where(m => m.HomeTeam != null && m.AwayTeam != null).Select(m => 
                    new MatchViewModel
                    {
                        Id = m.Id,
                        AwayTeamName = m.AwayTeam.Name,
                        HomeTeamName = m.HomeTeam.Name,
                        BeginDate = m.BeginDate
                    }).ToListAsync())

                    {
                        var homeTeamName = matchTeamNames.HomeTeamName;
                        var awayTeamName = matchTeamNames.AwayTeamName;
                        
                        var fixture = objResult.fixtures.Where(f =>
                            f.date == matchTeamNames.BeginDate
                            && f.homeTeamName == homeTeamName
                            && f.awayTeamName == awayTeamName
                            ).First();

                        var match = await _context.Matches.FirstAsync(m => m.Id == matchTeamNames.Id);

                        match.HomeTeamScore = fixture.result.goalsHomeTeam ?? 0;
                        match.AwayTeamScore = fixture.result.goalsAwayTeam ?? 0;

                        match.Began = fixture.date < DateTime.UtcNow;
                        match.Finished = fixture.status.ToLower() == "finished";
                        match.BeginDate = fixture.date;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public void Stop(bool immediate)
        {
            // Locking here will wait for the lock in Execute to be released until this code can continue.
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);
        }
    }
}