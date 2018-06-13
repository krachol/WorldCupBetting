using System;

namespace DFDSBetting.Models
{
    public class WinnerBetViewModel
    {
        public Guid TeamId { get; internal set; }
        public Guid Id { get; internal set; }
        public int Value { get; set; }
    }
}