using System;
using System.Data.Entity;

namespace DFDSBetting.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Char Group { get; set; }
        public string ApiLink { get; set; }
        public string FlagUrl { get; set; }
        public DbSet<WinnerBet> WinnerBets { get; set; }
    }
}