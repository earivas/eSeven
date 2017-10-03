using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Seven.Startup))]
namespace Seven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
