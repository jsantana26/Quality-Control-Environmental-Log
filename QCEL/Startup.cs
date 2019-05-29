using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QCEL.Startup))]
namespace QCEL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
