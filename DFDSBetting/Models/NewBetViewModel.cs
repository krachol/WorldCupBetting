using System;
using System.ComponentModel.DataAnnotations;

namespace DFDSBetting.Models
{
    public class NewScoreBetViewModel
    {
        [Required]
        public Guid MatchId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ScoreHome { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ScoreAway { get; set; }
    }
}