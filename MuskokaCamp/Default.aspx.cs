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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void parentSubmit_Click(object sender, EventArgs e)
        {

            // connect
            using (muskokaModel db = new muskokaModel())
            {
                // create guardian login object
                gaurdian objO = new gaurdian();

                String firstname = firstName.Text;
                String lastname = lastName.Text;

                objO = (from o in db.gaurdians
                        where o.firstName == firstname
                        && o.lastName == lastname
                        select o).FirstOrDefault();

                if (objO != null)
                {
                    // store the camperID in the session
                    Session["guardianID"] = objO.ID;

                    // redirect to sign in/out page
                    Response.Redirect("Parent/CamperAttendance.aspx?guardianID=" + objO.ID);
                }
                else
                {
                    lblError.Text = "Invalid Login";
                }
            }
        }
    }
}