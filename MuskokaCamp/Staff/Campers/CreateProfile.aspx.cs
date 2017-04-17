using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add success the database
using System.Web.ModelBinding;
using MuskokaCamp.Models;

namespace MuskokaCamp.Staff.Campers
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                // check for url ID
                if (!String.IsNullOrEmpty(Request.QueryString["camperID"]))
                {
                    // get the url
                    Int32 camperID = Convert.ToInt32(Request.QueryString["camperID"]);

                    // connect
                    var conn = new muskokaModel();

                    // look up the camper
                    var objCamper = (from c in conn.camperProfiles
                                    where c.camperID == camperID
                                    select c).FirstOrDefault();

                    // populate the form
                    firstName.Text = objCamper.firstName;
                    lastName.Text = objCamper.lastName;
                    rate.Text = objCamper.rate;
                    age.Text = Convert.ToString(objCamper.age);
                    address.Text = objCamper.address;
                    contactName.Text = objCamper.contactName;
                    contactRelation.Text = objCamper.contactRelation;
                    contactNumber.Text = objCamper.contactNumber;
                    impNotes.Text = objCamper.importantNotes;
                }
            }
        }
        
        protected void Create_Click(object sender, EventArgs e)
        {
           
              // check if we have an ID for editing
              Int32 camperID = 0;

              if (!String.IsNullOrEmpty(Request.QueryString["camperID"]))
              {

                  camperID = Convert.ToInt32(Request.QueryString["camperID"]);

              }

                  //connect to db
                  var conn = new muskokaModel();

                  //use camper class to create a new camper object
                  Models.camperProfile c = new Models.camperProfile();

                  //fill the properties of the new camper
                  c.firstName = firstName.Text;
                  c.lastName = lastName.Text;
                  c.familyName = familyName.Text;
                  c.rate = rate.Text;
                  c.age = Convert.ToInt32(age.Text);
                  c.address = address.Text;
                  c.contactName = contactName.Text;
                  c.contactRelation = contactRelation.Text;
                  c.contactNumber = contactNumber.Text;
                  c.importantNotes = impNotes.Text;

          //save the new object to the database
          if (camperID == 0)
              {
                  conn.camperProfiles.Add(c);
              }
              else
              {
                  c.camperID = camperID;
                  conn.camperProfiles.Attach(c);
                  conn.Entry(c).State = System.Data.Entity.EntityState.Modified;
              }

              conn.SaveChanges();

              //redirect to the Index page
              Response.Redirect("Index.aspx?");
              

        }

        
    }
}
