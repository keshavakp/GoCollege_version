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
    public partial class EditCollege : System.Web.UI.Page
    {
        AdminBL objAdminBL = new AdminBL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["UserName"] == null || Session["UserID"] == null || Session["UserType"] == null)
                    {
                        Response.Redirect("~/AdminLogin.aspx");
                    }
                    else
                    {
                        //  ResetAll();

                        BindCollege();
                    }
                }
                catch (Exception ex)
                {

                }
            }     


        }

        protected void collegebtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if(Session["CollegeID"] == null)
                {
                        Response.Redirect("~/AdminLogin.aspx");                    
                }

                DataView dv = new DataView();
                dv = objAdminBL.FetchForExistingClgDetails_EditCollegeUpdate(long.Parse(Session["CollegeID"].ToString()));
                int chkEmail = 0, chkMobile = 0, ChkPhone = 0, chkqry = 0;

                

                for (int i = 0; i < dv.Count; i++)
                {
                    if (dv[i]["CollegeEmail"].ToString().Equals(collgeEmail.Text.ToString()) && dv[i]["CollegePhone"].ToString().Equals(collegePhone.Text.ToString()) && dv[i]["CollegeMobile"].ToString().Equals(collegeMobile.Text.ToString()))
                    {
                        chkEmail = 1;
                        chkMobile = 1;
                        ChkPhone = 1;
                    }
                    else if (dv[i]["CollegeEmail"].ToString().Equals(collgeEmail.Text.ToString()) && dv[i]["CollegePhone"].ToString().Equals(collegePhone.Text.ToString()))
                    {
                        chkEmail = 1;
                        //chkMobile = 1;
                        ChkPhone = 1;

                    }
                    else if (dv[i]["CollegeEmail"].ToString().Equals(collgeEmail.Text.ToString()) && dv[i]["CollegeMobile"].ToString().Equals(collegeMobile.Text.ToString()))
                    {
                        chkEmail = 1;
                        chkMobile = 1;
                        //  ChkPhone = 1; 
                    }
                    else if (dv[i]["CollegePhone"].ToString().Equals(collegePhone.Text.ToString()) && dv[i]["CollegeMobile"].ToString().Equals(collegeMobile.Text.ToString()))
                    {
                        //  chkEmail = 1;
                        chkMobile = 1;
                        ChkPhone = 1;
                    }
                    else if (dv[i]["CollegeEmail"].ToString().Equals(collgeEmail.Text.ToString()))
                    {
                        chkEmail = 1;
                    }
                    else if (dv[i]["CollegePhone"].ToString().Equals(collegePhone.Text.ToString()))
                    {
                        ChkPhone = 1;
                    }
                    else if (dv[i]["CollegeMobile"].ToString().Equals(collegeMobile.Text.ToString()))
                    {
                        chkMobile = 1;
                    }

                }

                if (chkEmail == 1 && chkMobile == 1 && ChkPhone == 1)
                {
                    errMsg.Text = "Email ID, Mobile and Phone number already exists";
                }
                else if (chkEmail == 1 && chkMobile == 1)
                {
                    errMsg.Text = "Email ID, Mobile number already exists";
                }
                else if (chkEmail == 1 && ChkPhone == 1)
                {
                    errMsg.Text = "Email ID, Phone number already exists";
                }
                else if (chkEmail == 1)
                {
                    errMsg.Text = "Email already exists";
                }
                else if (chkMobile == 1)
                {
                    errMsg.Text = "Mobile number already exists";
                }
                else if (ChkPhone == 1)
                {
                    errMsg.Text = "Phone number already exists";
                }
                else
                {
                    chkqry = objAdminBL.UpdateCollegeDetails_EditUpdate(long.Parse(Session["CollegeID"].ToString()), collegeName.Text.ToString(), collgeEmail.Text.ToString(), Convert.ToInt64(collegePhone.Text.ToString()), Convert.ToInt64(collegeMobile.Text.ToString()), collegeAddress.Text.ToString());

                    if (chkqry == 1)
                    {
                        Response.Redirect("AdminHome.aspx");



                    }
                    else
                    {

                    }
                }
            }

        }

        protected void BindCollege()
        {
            if (Session["CollegeID"] == null)
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
            else
            {
                DataView dv = new DataView();

                dv = objAdminBL.FetchCollgeDetails(long.Parse(Session["UserID"].ToString()), Session["UserName"].ToString());

                if (!dv.Count.Equals(0))
                {
                    collegeName.Text = dv[0]["CollegeName"].ToString();
                    collegeAddress.Text = dv[0]["CollegeAddress"].ToString();
                    collgeEmail.Text = dv[0]["CollegeEmail"].ToString();
                    collegeMobile.Text = dv[0]["CollegeMobile"].ToString();
                    collegePhone.Text = dv[0]["CollegePhone"].ToString();
                }

            }

        }
    }
}