using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DFDSBetting.Models;

namespace DFDSBetting.Services
{
    internal class MatchService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public MatchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Match> GetByIdAsync(Guid matchId)
        {
            return await _context.Matches.FirstAsync(m => m.Id == matchId);
        }


        public MatchViewModel GetMatchViewModel(Match match)
        {
            return new MatchViewModel
            {
                Id = match.Id,
                HomeTeamName = match.HomeTeam.Name,
                HomeTeamScore = match.HomeTeamScore,
                AwayTeamName = match.AwayTeam.Name,
                AwayTeamScore = match.AwayTeamScore,
                BeginDate = match.BeginDate.AddHours(2),
                HomeTeamFlagUrl = match.HomeTeam.FlagUrl,
                AwayTeamFlagUrl = match.AwayTeam.FlagUrl,
            };
        }
    }
}