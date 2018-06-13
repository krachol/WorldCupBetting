using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DFDSBetting.Models;

namespace DFDSBetting.Services
{
    internal class PointsService
    {
        private ApplicationDbContext _context;

        public PointsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Request { get; private set; }

        internal async Task<int> GetPointsForUserAsync(ApplicationUser u)
        {
            int pointsFromWinnerBets = await GetPointsForUserFromWinnerBetsAsync(u);
            int pointsFromScoreBets = await GetPointsForUserFromScoreBetsAsync(u);
            return pointsFromScoreBets + pointsFromWinnerBets;
        }

        private async Task<int> GetPointsForUserFromScoreBetsAsync(ApplicationUser u)
        {
            List<ScoreBet> scorePredictedBets = await GetScorePredictedBetsAsync(u);
            List<ScoreBet> winnerPredictedBets = await GetWinnerPredictedBetsAsync(u);

            var points = scorePredictedBets.Count * 3 + winnerPredictedBets.Count;

            return points;
        }

        private async Task<List<ScoreBet>> GetWinnerPredictedBetsAsync(ApplicationUser u)
        {
            return await _context.ScoreBets
                .Where(b => 
                ((b.ScoreAway > b.ScoreHome && b.Match.AwayTeamScore > b.Match.HomeTeamScore) 
                || (b.ScoreAway < b.ScoreHome && b.Match.AwayTeamScore < b.Match.HomeTeamScore) 
                || (b.ScoreAway == b.ScoreHome && b.Match.AwayTeamScore == b.Match.HomeTeamScore))
                && b.Match.Began && b.Match.Finished
                ).ToListAsync();
        }

        private async Task<List<ScoreBet>> GetScorePredictedBetsAsync(ApplicationUser u)
        {
            return await _context.ScoreBets
                                        .Where(b =>
                                            b.Placer.Id == u.Id &&
                                            b.Match.Finished == true &&
                                            b.ScoreAway == b.Match.AwayTeamScore &&
                                            b.ScoreHome == b.Match.HomeTeamScore
                                        ).ToListAsync();
        }

        private async Task<int> GetPointsForUserFromWinnerBetsAsync(ApplicationUser u)
        {
            var bet = await _context.WinnerBets.Where(b => b.Placer.Id == u.Id && b.Team.IsChampion).FirstOrDefaultAsync();

            if (bet == null)
                return 0;
            else
            {
                return bet.Value;
            }
        }
    }
}