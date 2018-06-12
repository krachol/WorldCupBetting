using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFDSBetting.Models
{
    public class WinnerBet
    {
        public Guid Id{ get; set; }

        [Key]
        [Column(Order=1)]
        public ApplicationUser Placer { get; set; }

        [Key]
        [Column(Order=2)]
        public Team Team { get; set; }
    }
}