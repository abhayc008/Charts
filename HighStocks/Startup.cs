using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HighStocks.Startup))]
namespace HighStocks
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
