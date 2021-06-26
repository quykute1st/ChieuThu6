using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChieuThu6.Startup))]
namespace ChieuThu6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
