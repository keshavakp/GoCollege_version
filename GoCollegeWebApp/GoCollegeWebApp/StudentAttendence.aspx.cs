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
                    BindCourseNDate();
                    
                    BindAllStudentAttendence();
                }
           }
        }

        protected void BindAllStudentAttendence()
        {

            
        }

        public void BindCourseNDate()
        {
            DataView dv = new DataView();

            dv = objAdminBL.FetchAllCourse(long.Parse(Session["UserID"].ToString()));

            ddlstudentCourse.DataSource = dv;
            ddlstudentCourse.DataTextField = "CourseShortName";
            ddlstudentCourse.DataValueField = "CourseID";
            ddlstudentCourse.DataBind();
            ddlstudentCourse.Items.Insert(0, new ListItem(" Select ", "0"));

            txtDate.Text = DateTime.Now.ToShortDateString();
        }

        //Bind Sem
        protected void ddlstudentCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (long.Parse(ddlstudentCourse.SelectedValue.ToString()) == 0)
            {
                ddlstudentSemester.Items.Clear();
            }
            else
            {
                DataView dv = new DataView();

                dv = objAdminBL.FetchAllSemsByCourseID(long.Parse(ddlstudentCourse.SelectedValue.ToString()));


                ddlstudentSemester.DataSource = dv;
                ddlstudentSemester.DataTextField = "SemNumber";
                ddlstudentSemester.DataValueField = "SemID";
                ddlstudentSemester.DataBind();
                ddlstudentSemester.Items.Insert(0, new ListItem(" Select ", "0"));

            }
        }


        //Bind Section Subject Date
        protected void ddlstudentSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (long.Parse(ddlstudentSemester.SelectedValue.ToString()) == 0)
            {
                ddlSubject.Items.Clear();
                ddlSection.Items.Clear();
            }
            else
            {
                DataView dv = new DataView();

                dv = objAdminBL.FetchSubjectsBySemID(long.Parse(ddlstudentSemester.SelectedValue.ToString()));
                ddlSubject.DataSource = dv;
                ddlSubject.DataTextField = "SubjectName";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(0, new ListItem(" Select ", "0"));

                DataView dv1 = new DataView();

                dv1 = objAdminBL.FetchAllSectionBySemID(long.Parse(ddlstudentSemester.SelectedValue.ToString()));
                ddlSection.DataSource = dv1;
                ddlSection.DataTextField = "SectionName";
                ddlSection.DataValueField = "SectionID";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem(" Select ", "0"));


            }
        }

        protected void ddlstudentSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlstudentSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView();



            dv = objAdminBL.FetchAllStudentAttendence(Convert.ToDateTime(txtDate.Text.ToString()), Convert.ToDateTime(txtDate.Text.ToString()), 2016,
                long.Parse(ddlstudentCourse.SelectedValue.ToString()), long.Parse(ddlSection.SelectedValue.ToString()), 
                long.Parse(ddlSubject.SelectedValue.ToString()), "AdminViewStudentAttendence");

            if (! dv.Count.Equals(0))
            {
                dgStudentAttendenceDetails.DataSource = dv;
                dgStudentAttendenceDetails.DataBind();
            }
        }


        


    }
}