using Microsoft.Owin;
using Owin;

namespace Frostbite.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}