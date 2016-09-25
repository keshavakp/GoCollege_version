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
                    if (Session["AdminUserName"] == null || Session["AdminLogin"] == null || Session["UserType"] == null)
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

        public void BindCollgeCode()
        {
           
                if (Session["AdminUserName"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }



                string adminUserName = Session["AdminUserName"].ToString();

                txtCollgeCode.ReadOnly = true;

                DataView dv = new DataView();
                dv=objadminBL.FetchCollgeDetails(adminUserName);
                 if(!dv.Count.Equals(0))
                 {
                     txtCollgeCode.Text = dv[0]["CollegeCode"].ToString();

                 }
                 else
                 {

                 }

        }

        protected void btnUpdateCollege_Click(object sender, EventArgs e)
        {
 
        }

    }
}