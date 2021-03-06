﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuskokaCamp.Staff.Reports
{
    public partial class DailyCamperSheets : System.Web.UI.Page
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
    }
}