using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add success the database
using MuskokaCamp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


namespace MuskokaCamp.Staff
{
    public partial class ManageStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getStaff();
        }

        protected void getStaff()
        {
        
        }
        
    }
}