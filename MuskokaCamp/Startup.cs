using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartupAttribute(typeof(MuskokaCamp.Startup))]

namespace MuskokaCamp
{

    public partial class Startup {

        public void Configuration(IAppBuilder app) {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/StaffLogin.aspx")
            });

        }

    }
}
