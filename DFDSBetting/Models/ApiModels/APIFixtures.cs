using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFDSBetting.Models.ApiModels
{
    public class APIFixtures
    {
        public Links _links { get; set; }
        public List<Fixture> fixtures { get; set; }
    }
}