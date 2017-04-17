using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuskokaCamp.Staff.Campers
{
    public partial class RegistrationDates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getCampers();

            
        }

        protected void getCampers()
        {
            //connect to db
            var conn = new muskokaEntities();

            Int32 camperID = Convert.ToInt32(Request.QueryString["camperID"]);

            //run the query using LINQ
            var dates = from r in conn.registrationDates
                          where r.camperID == camperID
                          select r;


            //display the query results in grid view
            grdRegistration.DataSource = dates.ToList();
            grdRegistration.DataBind();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            using (muskokaEntities conn = new muskokaEntities())
            {
                //use camper class to create a new camper object
                registrationDate r = new registrationDate();

                Int32 camperID = Convert.ToInt32(Request.QueryString["camperID"]);

                //fill the properties of the new camper

                string phrase = datePick.Text;

                string[] words;

                string[] stringSeparators = new string[] { ", " };

                words = phrase.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in words)
                {

                    string str;

                    str = s;
                    //remove next two statment and enter value of str in database
                    r.date = str;
                    r.camperID = camperID;


                    //save the new object to the database
                    conn.registrationDates.Add(r);
                    conn.SaveChanges();
                }
            }

            //redirect
            getCampers();
        }

        protected void grdRegistration_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //function to delete a camper from the list of profiles
            // 1. determine row in the grid
            Int32 gridIndex = e.RowIndex;

            // 2. find the camper id value in the selected row
            Int32 ID = Convert.ToInt32(grdRegistration.DataKeys[gridIndex].Values["ID"]);

            Int32 camperID = Convert.ToInt32(Request.QueryString["camperID"]);

            // 3. connect to db
            using (muskokaEntities db = new muskokaEntities())
            {

                registrationDate camp = (from r in db.registrationDates
                                         where r.ID == ID && r.camperID == camperID   
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