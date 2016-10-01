using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoCollege_BL;

namespace GoCollegeWebApp
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        AdminBL objadminBL = new AdminBL();
        StudentBL objstudentBL = new StudentBL();

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
                        if (Session["UserType"] == "S")
                        {
                            BindRegistrationData();
                        }
                        else
                        {
                            Response.Redirect("~/AdminLogin.aspx");
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }

        }


        protected void BindRegistrationData()
        {
            txtStudentUSN.Text = Session["StudentUSN"].ToString();
            hfStudentID.Value = Session["UserID"].ToString();

            DataView dv = new DataView();

            dv = Session["StudentDataView"] as DataView;

            if (!dv.Count.Equals(0))
            {
                hfCoueseID.Value = dv[0]["CourseID"].ToString();
                hfSemID.Value = dv[0]["SemID"].ToString();

            }

        }



        //First Time Registration
        protected void studentbtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }

                DataView dv = new DataView();
                dv = objstudentBL.ChkForExistingContactDetails(long.Parse(hfStudentID.Value.ToString()), long.Parse(Session["CollegeID"].ToString()), long.Parse(txtStudentMobile.Text.ToString()), txtStudentEmail.Text.ToString());

                int chkmail = 0, chkmobile = 0;

                for (int i = 0; i < dv.Count; i++)
                {

                    if (txtStudentEmail.Text.ToString() == dv[i]["StudentEmail"].ToString() && txtStudentMobile.Text.ToString() == dv[i]["StudentMobile"].ToString())
                    {
                        chkmail = 1;
                        chkmobile = 1;
                        //errMsg.Text = "Email ID and Mobile Number already exists";
                    }
                    else if (txtStudentEmail.Text.ToString() == dv[i]["StudentEmail"].ToString())
                    {
                        chkmail = 1;
                        //errMsg.Text = "Mobile Number already exists";
                    }
                    else if (dv[i]["StudentMobile"].ToString() != "")
                    {

                        if (txtStudentMobile.Text.ToString() == dv[i]["StudentMobile"].ToString())
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


                    qryResult = objstudentBL.EditUpdateStudent(long.Parse(hfStudentID.Value.ToString()),long.Parse(Session["CollegeID"].ToString()), txtStudentUSN.Text.ToString(),
                        
                        txtStudentName.Text.ToString(),txtStudentEmail.Text.ToString(), long.Parse(txtStudentMobile.Text.ToString()), txtStudentAddress.Text.ToString(), long.Parse(hfCoueseID.Value.ToString()), 
                        
                        long.Parse(hfSemID.Value.ToString()), txtStudentNewPassword.Text.ToString(),"A" );

                    

                    if (qryResult == 1)
                    {

                        Response.Redirect("StudentHome.aspx");
                  
                        // ResetAll();
                        
                    }
                    else
                    {
                    }
                }


            }

        }

       



    }
}