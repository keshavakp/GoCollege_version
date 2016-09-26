using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoCollegeWebApp
{
    public partial class EditCollege : System.Web.UI.Page
    {
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
                        //  ResetAll();
                    }
                }
                catch (Exception ex)
                {

                }
            }     


        }

        protected void collegebtnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}