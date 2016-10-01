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
    public partial class AdminEditDetails : System.Web.UI.Page
    {
        AdminBL objadminBL = new AdminBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["UserName"] == null || Session["UserID"] == null || Session["UserType"] == null )
                    {
                        Response.Redirect("~/AdminLogin.aspx");
                    }
                    else
                    {
                        if (Session["UserType"].ToString() == "A")
                        {
                            ResetAll();
                        }
                        else
                        {
                            Response.Redirect("~/AdminLogin.aspx");
                        }

                    }
                }
                catch(Exception ex)
                {

                }
            }
        }

        protected void adminbtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (Session["AdminUserName"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                
                string adminUserName = Session["AdminUserName"].ToString();      
                string adminUN = Session["AdminUserName"].ToString();
                string adminNAME = adminName.Text.ToString(); 
                string adminPWD = adminPassword.Text.ToString();
                string adminEMAIL = adminEmail.Text.ToString();
                Int64 adminMOBILE = Convert.ToInt64(adminMobile.Text.ToString());

                DataView dv = new DataView();
                dv = objadminBL.ChkForExisting();

                int chkmail=0, chkmobile=0;

                for (int i = 0; i < dv.Count; i++)
                {

                    if (adminEMAIL == dv[i]["AdminEmail"].ToString() && adminMOBILE == Convert.ToInt64(dv[i]["AdminMobile"].ToString()))
                    {
                        chkmail = 1;
                        chkmobile = 1;
                        //errMsg.Text = "Email ID and Mobile Number already exists";
                    }
                    else if ( adminEMAIL == dv[i]["AdminEmail"].ToString())
                    {
                        chkmail = 1;
                        //errMsg.Text = "Mobile Number already exists";
                    }
                    else if (dv[i]["AdminMobile"].ToString() != "")
                    {

                        if (adminMOBILE == Convert.ToInt64(dv[i]["AdminMobile"].ToString()) )
                        {
                            chkmobile = 1;
                        }
                    }
                }


                if (chkmobile == 1 && chkmail == 1)
                {
                    errMsg.Text = "Email ID and Mobile Number already exists"; 
                }
                else if (chkmail == 1) 
                {
                    errMsg.Text = "Email ID already exists";
                }
                else if (chkmobile == 1)
                {
                    errMsg.Text = "Mobile Number already exists";

                }

                else
                {
                    int qryResult = 0;
                    qryResult = objadminBL.EditAdmin(adminUN, adminNAME, adminEMAIL, adminMOBILE, adminPWD);

                    if (qryResult == 0)
                    {

                        // ResetAll();

                    }
                    else
                    {
                        Response.Redirect("EditCollege.aspx");
                    }
                }
            }


        }

        public void ResetAll()
        {
            string s = "<script language=javascript>  document.getElementById('" + adminName.ClientID + "').focus(); </script>";
            ClientScript.RegisterStartupScript(GetType(), "Focus", s);
                      
            adminName.Text = "";
            adminEmail.Text = "";
            adminMobile.Text = "";           
            adminPassword.Text = "";
            adminConfirmPassword.Text = "";
            errMsg.Text = "";
        }
    }
}