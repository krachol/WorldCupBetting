using System;

namespace DFDSBetting.Models
{
    public class MatchViewModel
    {
        public Guid Id { get; set; }
        public DateTime BeginDate { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public string HomeTeamFlagUrl { get; set; }
        public string AwayTeamFlagUrl { get; set; }
        public bool Began { get; set; }
    }
}