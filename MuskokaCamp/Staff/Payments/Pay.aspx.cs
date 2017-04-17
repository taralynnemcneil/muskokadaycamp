﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add success the database
using System.Web.ModelBinding;
using MuskokaCamp.Models;
using System.Data;
using System.Data.SqlClient;

namespace MuskokaCamp.Staff.Payments
{
    public partial class Pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {
                // get the id from the url
                Int32 camperID = Convert.ToInt32(Request.QueryString["camperID"]);

                // connect
                var conn = new muskokaModel();

                // look up the camper
                var objCamper = (from c in conn.camperProfiles
                                where c.camperID == camperID
                                select c).FirstOrDefault();

                var objPayment = (from p in conn.payments
                                 where p.camperID == camperID
                                 select p).FirstOrDefault();

                // run the query using LINQ
                var payment = (from p in conn.payments
                               where p.camperID == camperID
                               select p);

                // display the query results in grid view
                grdPayment.DataSource = payment.ToList();
                grdPayment.DataBind();

                // populate the camper form
                familyName.Text = objCamper.familyName;
                firstName.Text = objCamper.firstName;
                rate.Text = "$" + objCamper.rate;
            }
            
        }

        protected void submitPayment_Click(object sender, EventArgs e)
        {
            Int32 camperID = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["camperID"]))
            {
                camperID = Convert.ToInt32(Request.QueryString["camperID"]);
            }

            // connect to db
            var conn = new muskokaModel();

            // use the payment class to create new payment
            Models.payment p = new Models.payment();

            p.date = payCalendar.Text;
            p.amount = "$" + makePayment.Text;
            p.payment_type = payType.SelectedItem.Text;
            p.camperID = Convert.ToInt32(Request.QueryString["camperID"]);

            if (camperID == 0)
            {
                lblPayment.Text = "Cannot Submit Payment";
            }
            else
            {
                p.camperID = camperID;
                conn.payments.Attach(p);
                conn.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }

            conn.SaveChanges();
            
            //redirect
            Response.Redirect("Pay.aspx");

        }
    }
}   