using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFDSBetting.Models.ApiModels
{
    public class Links
    {
        public Link self { get; set; }
        public Link competition { get; set; }
        public int count { get; set; }
    }
}