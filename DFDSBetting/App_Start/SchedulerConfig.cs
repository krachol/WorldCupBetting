using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFDSBetting.App_Start
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<MatchUpdater>().ToRunNow().AndEvery(15).Seconds();
        }
    }
}