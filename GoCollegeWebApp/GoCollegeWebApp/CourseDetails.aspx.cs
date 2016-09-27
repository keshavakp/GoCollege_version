using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GoCollege_BL;

namespace GoCollegeWebApp
{
    public partial class CourseDetails : System.Web.UI.Page
    {
        AdminBL objAdmin = new AdminBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUserName"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                BindCourse();
            }

        }

        protected void BindCourseGrid()
        {
 
        }

        protected void coursebtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int chkquery = 0;

                chkquery = objAdmin.AddCourse(cName.Text.ToString(), cShortName.Text.ToString(),Convert.ToInt16(cNoSems.Text.ToString()), Convert.ToInt64(Session["CollegeID"].ToString()));

                if (chkquery == 1)
                {
                    errMsg.CssClass = "errMsg";
                    errMsg.Text = "Course Added Successfully";
                }
                else if (chkquery == -1)
                {
                    errMsg.CssClass = "errMsg";
                    errMsg.Text = "Duplicate Course Details";
                }
                else
                {
                    errMsg.Text = "Failed to add course";
                }
            }


        }

        //Edit Click
        protected void btnEdit_Command(object sender, EventArgs e)
        {

        
        }

        //
        protected void dgCourse_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
        
        }

        protected void BindCourse()
        {
            DataView dv = new DataView();
            dv = objAdmin.FetchAllCourse(Convert.ToInt64(Session["AdminID"].ToString()));

            if (dv.Count > 0)
            {
                dgCourseDetails.DataSource = dv;
                dgCourseDetails.DataBind();
            }
        }


        protected void editcoursebtnSubmit_Click(object sender, EventArgs e)
        {

        }


        protected void dgCourseDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}