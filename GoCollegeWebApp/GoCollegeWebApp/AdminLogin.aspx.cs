using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoCollege_BL;
using System.Data;


namespace GoCollegeWebApp
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        AdminBL objadminBL = new AdminBL();

        protected void Page_Load(object sender, EventArgs e)
        {

                if (!Page.IsPostBack)
                {
                    try
                    {
                        //Reset Admin Sessions
                        Session["AdminID"] = null;
                        Session["AdminUserName"] = null;
                        Session["AdminLogin"] = null;
                        Session["UserType"] = null;
                        ResetAll();
                    }
                    catch(Exception ex)
                    {

                    }
                }
         }

        protected void adminLoginbtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
               DataView dv = new DataView();
               dv = objadminBL.AdminLogin(adminUserName.Text.ToString(), adminPassword.Text.ToString());

               if (!dv.Count.Equals(0))
               {                 

                   if ( dv[0]["AdminStatus"].ToString().Equals("R"))
                   {
                       //Set Admin Sessions
                       Session["AdminID"] = dv[0]["AdminID"].ToString();
                       Session["AdminUserName"] = adminUserName.Text.ToString(); 
                       Session["AdminLogin"] = "true";
                       Session["UserType"] = "Admin";
                       Response.Redirect("~/AdminEditDetails.aspx");
                   }
                   else if (dv[0]["AdminStatus"].ToString().Equals("A"))
                   {
                       //Set Admin Sessions
                       Session["AdminID"] = dv[0]["AdminID"].ToString();
                       Session["AdminUserName"] = adminUserName.Text.ToString(); 
                       Session["AdminLogin"] = "true";
                       Session["UserType"] = "Admin";
                       Response.Redirect("~/AdminUpdateCollege.aspx");

                   }

               }
               else
               {
                   errMsg.Text = "Invalid User Name and Password";
               }

            }

        }

        public void ResetAll()
        {
            string s = "<script language=javascript>  document.getElementById('" + adminUserName.ClientID + "').focus(); </script>";
            ClientScript.RegisterStartupScript(GetType(), "Focus", s);
            adminUserName.Text = "";
            adminPassword.Text = "";
        }

    }
}