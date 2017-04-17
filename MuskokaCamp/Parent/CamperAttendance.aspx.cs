using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using MuskokaCamp.Models;
using System.Data.SqlClient;


namespace MuskokaCamp.Parent
{
    public partial class CamperAttendence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Show current Date
            currentDate.Text = DateTime.Now.DayOfWeek.ToString();
            currentDate2.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            if (!IsPostBack)
            {
                //if we have an ID in the url, look up the selected record
                if (!String.IsNullOrEmpty(Request.QueryString["guardianID"]))
                {
                    GetCampers();
                }
            }
        }


        protected void GetCampers()
        {
            using (muskokaModel db = new muskokaModel())
            {
                // store the id from the url in a variable
                Int32 guardianID = Convert.ToInt32(Request.QueryString["guardianID"]);

                // look up the campers related to that name
                var campers = (from c in db.camperProfiles
                               from g in c.gaurdians
                               where g.ID == guardianID
                               select c);

                grdCampers.DataSource = campers.ToList();
                grdCampers.DataBind();

            }
           
        }
    }
}