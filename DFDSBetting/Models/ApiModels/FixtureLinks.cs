using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFDSBetting.Models.ApiModels
{
    public class FixtureLinks
    {
        public Link self { get; set; }
        public Link competition { get; set; }
        public Link homeTeam { get; set; }
        public Link awayTeam { get; set; }
    }
}