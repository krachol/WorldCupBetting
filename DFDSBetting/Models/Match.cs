using System;

namespace DFDSBetting.Models
{
    public class Match
    {
        public Guid Id { get; set; }
        public DateTime BeginDate { get; set; }
        public bool Began { get; set; }
        public bool Finished { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}