using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_153264_152728.Startup))]
namespace _153264_152728
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
