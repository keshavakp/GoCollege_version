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
    public partial class StudentAttendence : System.Web.UI.Page
    {
        AdminBL objAdminBL = new AdminBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                else
                {
                    BindAllStudentAttendence();
                }
           }
        }

        protected void BindAllStudentAttendence()
        {

        }
    }
}