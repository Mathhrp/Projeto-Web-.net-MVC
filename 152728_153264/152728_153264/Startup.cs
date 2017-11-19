using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_152728_153264.Startup))]
namespace _152728_153264
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
