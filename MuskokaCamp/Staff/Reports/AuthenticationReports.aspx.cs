using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuskokaCamp.Staff.Reports
{
    public partial class AuthenticationReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Getparents();
        }


        protected void submitDate_Click(object sender, EventArgs e)
        {
        }
        protected void Getparents()
        {
            using (muskokaEntities conn = new muskokaEntities())
            {
                var camperDates = (from cp in conn.camperProfiles

                                   join r in conn.registrationDates on cp.camperID equals r.camperID

                                   where r.date == datebox1.Text

                                   select new { cp.camperID, cp.familyName, cp.firstName, r.signInTime, r.signOutTime, r.signedInBy, r.signedOutBy, r.date });

                grdParents.DataSource = camperDates.ToList();

                grdParents.DataBind();
            }

        }
    }
}