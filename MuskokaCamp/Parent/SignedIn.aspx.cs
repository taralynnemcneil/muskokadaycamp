using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuskokaCamp.Parent
{
    public partial class SignedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Show current Date
            currentDate.Text = DateTime.Now.DayOfWeek.ToString();
            currentDate2.Text = DateTime.Now.ToString("MM-dd-yyyy").Replace("-","/");




            if (IsPostBack == false)
            {
                //check the url for an ID for editing
                if (!String.IsNullOrEmpty(Request.QueryString["camperID"]))
                {
                    // get the ID from url
                    Int32 camperID = Convert.ToInt32(Request.QueryString["camperID"]);

                    // connect to db
                    var conn = new muskokaEntities();

                    // look up the selected camper
                    var objCamper = (from r in conn.registrationDates where r.camperID == camperID && r.date == currentDate2.Text
                                    select r).FirstOrDefault();
                    // populate the form
                    signedOutBy.Text = objCamper.signedOutBy;


                }
            }

        }

        protected void signout_Click(object sender, EventArgs e)
        {
            // check if we have an ID for editing
            Int32 camperID = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["camperID"]))
            {

                camperID = Convert.ToInt32(Request.QueryString["camperID"]);

            }

            //connect to db
            var conn = new muskokaEntities();

            //use camper class to create a new camper object
            registrationDate render = (from r in conn.registrationDates
                          where r.camperID == camperID && r.date == currentDate2.Text
                          select r).First();

            //fill the properties of the camper time
            render.signedOutBy = signedOutBy.Text;
            render.signOutTime = DateTime.Now.ToString("h:mm:ss tt");

            conn.registrationDates.Attach(render);
            conn.Entry(render).State = System.Data.Entity.EntityState.Modified;
            conn.SaveChanges();

            //redirect
            Response.Redirect("CamperAttendence.aspx");
        }
    }
}