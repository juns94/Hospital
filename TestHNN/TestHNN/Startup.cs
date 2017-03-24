using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestHNN.Startup))]
namespace TestHNN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
