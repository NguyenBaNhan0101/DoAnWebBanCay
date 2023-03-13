using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAnWebBanCay.Startup))]
namespace DoAnWebBanCay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
