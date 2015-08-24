using Microsoft.Owin;
using NoteeFY;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace NoteeFY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
