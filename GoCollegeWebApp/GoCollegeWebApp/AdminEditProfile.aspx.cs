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
    public partial class AdminEditProfile : System.Web.UI.Page
    {
        AdminBL objAdminBL = new AdminBL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            PasswordBL ibjPasswordBL = new PasswordBL();

            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("AdminLogin");
                }
                else
                {
                    BindProfileData();
                }
            }
        }

        public void BindProfileData()
        {
            DataView dv = new DataView();

            dv = objAdminBL.FetchFor_AdminEditProfile(long.Parse(Session["UserID"].ToString()));

            if (!dv.Count.Equals(0))
            {
                txtName.Text = dv[0]["AdminName"].ToString();
                txtEmail.Text = dv[0]["AdminEmail"].ToString();
                txtMobile.Text = dv[0]["AdminMobile"].ToString();
            }
        }

        protected void btnAdminUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int qry = objAdminBL.FetchFor_AdminExistingMobileAndEmail(long.Parse(Session["UserID"].ToString()), long.Parse(txtMobile.Text.ToString()), txtEmail.Text.ToString());

                if (qry == 1)
                {
                    errMsg.Text = "Email and Mobile Number Already Exists"; 
                }
                else if (qry == 2)
                {
                    errMsg.Text = "Mobile Number Already Exists"; 
                }
                else if (qry == 3)
                {
                    errMsg.Text = "Email Already Exists";

                }
                else
                {
                    int result =0;
                    result = objAdminBL.UpdateAdminProfile(long.Parse(Session["UserID"].ToString()), long.Parse(txtMobile.Text.ToString()), txtEmail.Text.ToString(), txtName.Text.ToString());

                    if (result == 1)
                    {
                        errMsg.Text = "Profile Updated Successfully";
                        BindProfileData();
                    }
                }

            }
        }
    }
}