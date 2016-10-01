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
                        //Session["UserID"] = null;
                        //Session["UserName"] = null;
                        //Session["UserType"] = null;
                        //Session["CollegeID"]= nulll;
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

               dv.Table.Columns.Contains("AdminID");
              
        
               if (!dv.Count.Equals(0))
               {
                   if (dv.Table.Columns.Contains("StudentID"))
                   {

                       if (dv[0]["StudentStatus"].ToString().Equals("R"))
                       {
                           //Set Admin Sessions
                           Session["CollegeID"] = dv[0]["CollegeID"].ToString();
                           Session["UserID"] = dv[0]["StudentID"].ToString();
                           Session["UserName"] = adminUserName.Text.ToString();
                           //Session["AdminLogin"] = "true";
                           Session["UserType"] = "S";
                           Session["StudentUSN"] = dv[0]["StudentUSN"].ToString();
                           Session["StudentDataView"] = dv;
                           Response.Redirect("~/StudentRegistration.aspx");
                       }
                       else if (dv[0]["StudentStatus"].ToString().Equals("A"))
                       {
                           //Set Admin Sessions
                           Session["CollegeID"] = dv[0]["CollegeID"].ToString();
                           Session["UserID"] = dv[0]["StudentID"].ToString();
                           Session["UserName"] = adminUserName.Text.ToString();
                           // Session["AdminLogin"] = "true";
                           Session["UserType"] = "S";
                           Response.Redirect("~/StudentHome.aspx");

                       }
 
                   }
                   else if (dv.Table.Columns.Contains("AdminID"))
                   {

                       if (dv[0]["AdminStatus"].ToString().Equals("R"))
                       {
                           //Set Admin Sessions
                           Session["CollegeID"] = dv[0]["CollegeID"].ToString();
                           Session["UserID"] = dv[0]["AdminID"].ToString();
                           Session["UserName"] = adminUserName.Text.ToString();
                           //Session["AdminLogin"] = "true";
                           Session["UserType"] = "A";
                           Response.Redirect("~/AdminEditDetails.aspx");
                       }
                       else if (dv[0]["AdminStatus"].ToString().Equals("A"))
                       {
                           //Set Admin Sessions
                           Session["CollegeID"] = dv[0]["CollegeID"].ToString();
                           Session["UserID"] = dv[0]["AdminID"].ToString();
                           Session["UserName"] = adminUserName.Text.ToString();
                           // Session["AdminLogin"] = "true";
                           Session["UserType"] = "A";
                           Response.Redirect("~/AdminUpdateCollege.aspx");

                       }
                   }

                   else if (dv.Table.Columns.Contains("FacultyID"))
                   {

                       if (dv[0]["FacultyStatus"].ToString().Equals("R"))
                       {
                           //Set Admin Sessions
                           Session["CollegeID"] = dv[0]["CollegeID"].ToString();
                           Session["UserID"] = dv[0]["FacultyID"].ToString();
                           Session["UserName"] = adminUserName.Text.ToString();
                           //Session["AdminLogin"] = "true";
                           Session["UserType"] = "A";
                           Response.Redirect("~/AdminEditDetails.aspx");
                       }
                       else if (dv[0]["FacultyStatus"].ToString().Equals("A"))
                       {
                           //Set Admin Sessions
                           Session["CollegeID"] = dv[0]["CollegeID"].ToString();
                           Session["UserID"] = dv[0]["FacultyID"].ToString();
                           Session["UserName"] = adminUserName.Text.ToString();
                           // Session["AdminLogin"] = "true";
                           Session["UserType"] = "A";
                           Response.Redirect("~/FacultyHome.aspx");

                       }
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