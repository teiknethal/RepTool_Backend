using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RepToolService.Startup))]

namespace RepToolService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}