using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DevDay.Startup))]
namespace DevDay
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}