using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MuskokaCamp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


namespace MuskokaCamp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void staffSubmit_Click(object sender, EventArgs e)
        {
            // connect
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // try to find user
            var user = userManager.Find(userName.Text, password.Text);

            // if the user is found
            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties()
                {
                    IsPersistent = false
                }, userIdentity);

                Response.Redirect("Staff/StaffDashboard.aspx");
                
            }
            else
            {
                lblMessage.Text = "Invalid Login.";
            }

        }
    }
}