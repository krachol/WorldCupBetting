using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DFDSBetting.Startup))]
namespace DFDSBetting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}