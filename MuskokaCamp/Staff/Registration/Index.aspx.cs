using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuskokaCamp.Staff.Registration
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            getCampers();


        }


        protected void submitDate_Click(object sender, EventArgs e)
        {
            date.Text = datebox1.Text;
        }

        protected void getCampers()
        {
            //connect to db
            var conn = new muskokaEntities();

            //run the query using LINQ
            var camperDates = (from cp in conn.camperProfiles

                               join r in conn.registrationDates on cp.camperID equals r.camperID
                               where r.date == datebox1.Text

                               select new { cp.camperID, cp.familyName, cp.firstName, r.signInTime, r.signOutTime, r.signedInBy, r.signedOutBy });

            //display the query results in grid view
            grdRegistration.DataSource = camperDates.ToList();
            grdRegistration.DataBind();
        }
        protected void grdRegistration_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //function to delete a camper from the list of profiles
            // 1. determine row in the grid
            Int32 gridIndex = e.RowIndex;

            // 2. find the camper id value in the selected row
            Int32 camperID = Convert.ToInt32(grdRegistration.DataKeys[gridIndex].Values["camperID"]);
            var date = datebox1.Text;

            // 3. connect to db
            using (muskokaEntities db = new muskokaEntities())
            {

                registrationDate camp = (from r in db.registrationDates
                                         where r.camperID == camperID && r.date == date 
                                         select r).FirstOrDefault();

                // 4. delete the selected camper
                db.registrationDates.Remove(camp);
                db.SaveChanges();

                // 5. referesh the grid
                getCampers();
            }
        }
    }
}
