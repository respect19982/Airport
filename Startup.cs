using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Airport_IS.Startup))]
namespace Airport_IS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
