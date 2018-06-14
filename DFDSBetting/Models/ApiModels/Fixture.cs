using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFDSBetting.Models.ApiModels
{
    public class Fixture
    {
        public FixtureLinks _links { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public int? matchday { get; set; }
        public string homeTeamName { get; set; }
        public string awayTeamName { get; set; }
        public FixtureResult result { get; set; }
        public string odds { get; set; }
    }
}