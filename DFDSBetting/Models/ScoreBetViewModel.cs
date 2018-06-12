using System;
using System.ComponentModel.DataAnnotations;

namespace DFDSBetting.Models
{
    public class ScoreBetViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ScoreAway { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ScoreHome { get; set; }
    }
}