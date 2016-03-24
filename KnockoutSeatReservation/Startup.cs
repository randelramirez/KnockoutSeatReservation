using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnockoutSeatReservation.Startup))]
namespace KnockoutSeatReservation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
