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
                string adminUN, adminPWD;

                // Fetching Values from Text Box
                adminUN = adminUserName.Text.ToString();
                adminPWD = adminPassword.Text.ToString();

               DataView dv = new DataView();
               dv = objadminBL.AdminLogin(adminUN, adminPWD);

               if (!dv.Count.Equals(0))
               {

                   string isFirstTimeLogin;

                   isFirstTimeLogin = dv[0]["AdminStatus"].ToString();

                   if (isFirstTimeLogin.Equals("R"))
                   {
                       //Set Admin Sessions

                       Session["AdminUserName"] = adminUN;
                       Session["AdminLogin"] = "true";
                       Session["UserType"] = "Admin";
                       Response.Redirect("~/AdminEditDetails.aspx");
                   }
                   else if (isFirstTimeLogin.Equals("A"))
                   {
                       //Set Admin Sessions

                       Session["AdminUserName"] = adminUN;
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