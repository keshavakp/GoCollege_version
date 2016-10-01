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
            if (Session["UserName"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                if (Session["UserType"] == "A")
                {
                    BindCourse();
                }
                else
                {
                    Response.Redirect("~/AdminLogin.aspx");
                }
            }

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
                    BindCourse();
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
        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            divDataGrid.Visible = false;
            divAdd.Visible = false;
            divEdit.Visible = true;

            DataView dv = objAdmin.FetchCourseForEdit(Convert.ToInt64(e.CommandName.ToString()));

            editcName.Text = dv[0]["CourseName"].ToString();
            editcShortName.Text = dv[0]["CourseShortName"].ToString();
            editcTotalSems.Text = dv[0]["CourseTotalSems"].ToString();

            hfcourseID.Value = e.CommandName.ToString();
        }

        //Course Edit Update
        protected void editcoursebtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int result = 0;

                result = objAdmin.UpdateCourseDetails(Convert.ToInt64(hfcourseID.Value.ToString()),editcName.Text.ToString(),editcShortName.Text.ToString(),Convert.ToInt16(editcTotalSems.Text.ToString()), Convert.ToInt64(Session["CollegeID"].ToString()));

                if (result == 1)
                {
                    errMsg.Text = "Course Datails Updated Successfully";
                    BindCourse();
                }
                else
                {
                    errMsg.Text = "";
                }
 
            }

        }

        //DElete Click
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int result = objAdmin.DeleteCourse(Convert.ToInt64(e.CommandName.ToString()));
            if (result == 1)
            {
                errMsg.Text = "Course Deleted Succssfully";
                BindCourse();
            }
            else
            {
 
            }
 
        }


        //
        protected void dgCourse_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
        {
        
        }

        protected void BindCourse()
        {
            divAdd.Visible = false;
            divEdit.Visible = false;
            divDataGrid.Visible = true;

            DataView dv = new DataView();
            dv = objAdmin.FetchAllCourse(Convert.ToInt64(Session["UserID"].ToString()));

            if (dv.Count > 0)
            {
                dgCourseDetails.DataSource = dv;
                dgCourseDetails.DataBind();
            }
        }

        
        protected void dgCourseDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Load Grid
        protected void lnkViewAll(object sender, EventArgs e)
        {
            BindCourse();
        }

        public void ResetAll()
        {
            errMsg.Text = "";
        }

        //Link Add new 
        protected void lnkAddNewCourse(object sender, EventArgs e)
        {
            divAdd.Visible = true;
            divDataGrid.Visible = false;
            divEdit.Visible = false;
        }
    }
}