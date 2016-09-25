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
            if (Session["AdminUserName"].Equals(null) || Session["AdminLogin"].Equals(null) || Session["UserType"].Equals(null))

            {
                Response.Redirect("~/AdminLogin.aspx");
                
            
            }
                       


        }

        protected void collegebtnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}