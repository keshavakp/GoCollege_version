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
    public partial class AdminUpdateCollege : System.Web.UI.Page
    {
        AdminBL objadminBL = new AdminBL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["AdminID"] == null || Session["AdminUserName"] == null ) //|| Session["AdminLogin"] == null || Session["UserType"] == null)
                    {
                        Response.Redirect("~/AdminLogin.aspx");
                    }
                    else
                    {
                        BindCollgeCode();
                      //  ResetAll();
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }

        //Bind College Code
        public void BindCollgeCode()
        {
           
                if (Session["AdminUserName"] == null || Session["AdminID"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }

                string adminUserName = Session["AdminUserName"].ToString();

                txtCollgeCode.ReadOnly = true;

                DataView dv = new DataView();
                dv=objadminBL.FetchCollgeDetails( Convert.ToInt64(Session["AdminID"].ToString()), Session["AdminUserName"].ToString());

                 if(!dv.Count.Equals(0))
                 {                                     

                     if (dv[0]["CollegeStatus"].ToString().Equals("R"))
                     {
                         txtCollgeCode.Text = dv[0]["CollegeCode"].ToString();
                     }
                     else if (dv[0]["CollegeStatus"].ToString().Equals("A"))
                     {
                         Response.Redirect("AdminHome.aspx");
                     }
                 }                 

                 else
                 {

                 }

        }


        //Update College Details
        protected void btnUpdateCollege_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                DataView dv = new DataView();
                dv = objadminBL.ChkForExistingCollegeDetails();
                int chkEmail=0, chkMobile=0, ChkPhone = 0,chkqry=0;

                for(int i=0; i < dv.Count ; i++)
                {
                    if (dv[i]["CollegeEmail"].ToString().Equals(txtCollegeEmail.Text.ToString()) && dv[i]["CollegePhone"].ToString().Equals(txtCollegePhone.Text.ToString()) && dv[i]["CollegeMobile"].ToString().Equals(txtCollegeMobile.Text.ToString()))
                    {
                        chkEmail = 1;
                        chkMobile = 1;
                        ChkPhone = 1;
                    }
                    else if (dv[i]["CollegeEmail"].ToString().Equals(txtCollegeEmail.Text.ToString()) && dv[i]["CollegePhone"].ToString().Equals(txtCollegePhone.Text.ToString()))
                    {
                        chkEmail = 1;
                        //chkMobile = 1;
                        ChkPhone = 1;
 
                    }
                    else if (dv[i]["CollegeEmail"].ToString().Equals(txtCollegeEmail.Text.ToString()) && dv[i]["CollegeMobile"].ToString().Equals(txtCollegeMobile.Text.ToString()))
                    {
                        chkEmail = 1;
                        chkMobile = 1;
                      //  ChkPhone = 1; 
                    }
                    else if (dv[i]["CollegePhone"].ToString().Equals(txtCollegePhone.Text.ToString()) && dv[i]["CollegeMobile"].ToString().Equals(txtCollegeMobile.Text.ToString()))
                    {
                      //  chkEmail = 1;
                        chkMobile = 1;
                         ChkPhone = 1;  
                    }
                    else if(dv[i]["CollegeEmail"].ToString().Equals(txtCollegeEmail.Text.ToString()))
                    {
                        chkEmail = 1;
                    }
                    else if (dv[i]["CollegePhone"].ToString().Equals(txtCollegePhone.Text.ToString()))
                    {
                        ChkPhone = 1;                          
                    }
                    else if (dv[i]["CollegeMobile"].ToString().Equals(txtCollegeMobile.Text.ToString()))
                    {
                        chkMobile = 1;                        
                    }                    

                }

                if (chkEmail == 1 && chkMobile == 1 && ChkPhone == 1)
                {
                    errMsg.Text = "Email ID, Mobile and Phone number already exists";
                }
                else if (chkEmail==1 && chkMobile==1)
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
                    chkqry = objadminBL.UpdateCollegeDetails(txtCollgeCode.Text.ToString(), txtCollegeName.Text.ToString(), txtCollegeEmail.Text.ToString(), Convert.ToInt64(txtCollegePhone.Text.ToString()), Convert.ToInt64(txtCollegeMobile.Text.ToString()), txtCollegeAddress.Text.ToString());

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

    }
}