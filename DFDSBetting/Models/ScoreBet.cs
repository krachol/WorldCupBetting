using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFDSBetting.Models
{
    public class ScoreBet
    {
        public Guid Id { get; set; }

        [Key]
        [Column(Order=1)]
        public ApplicationUser Placer { get; set; }

        [Key]
        [Column(Order=2)]
        public Match Match { get; set; }

        public int ScoreHome { get; set; }
        public int ScoreAway { get; set; }
    }
}