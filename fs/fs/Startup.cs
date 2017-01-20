using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fs.Startup))]
namespace fs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
