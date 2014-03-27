using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasDetAjaxEdit.Startup))]
namespace MasDetAjaxEdit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
