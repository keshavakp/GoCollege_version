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
    public partial class SemesterManagement : System.Web.UI.Page
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

                }
            }

        }

        protected void BindSemester()
        {
            if (Session["CollegeID"] == null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            else
            {

            }
        }

        public void BindCourse()
        {
            DataView dv = new DataView();

            dv = objAdminBL.FetchAllCourse(long.Parse(Session["UserID"].ToString()));

            ddlCourse.DataSource = dv;

            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
            //ddlstudentCourse.
            ddlCourse.Items.Insert(0, new ListItem(" Select ", "0"));
        }

        //Add new click
        protected void lnkAddNewSemester(object sender, EventArgs e)
        {
            BindCourse();
           // BindSemester();
           // divEdit.Visible = false;
            divAdd.Visible = true;
           // divDataGrid.Visible = false;

        }

        //View All click
        protected void lnkViewAll(object sender, EventArgs e)
        {
            BindSemester();
           // ResetAll();
        }

        protected void ddlstudentSem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnSemesterAddSubmit_Click(object sender, EventArgs e)
        {
            int qry=0;

            if (Page.IsValid)
            {
                qry = objAdminBL.AddNewSemester(Convert.ToInt16(txtsemeNum.Text.ToString()), long.Parse(ddlCourse.SelectedValue.ToString()), long.Parse(txtsemTotalSubjects.Text.ToString()));

                if (qry == 1)
                {
                    errMsg.Text = "Semester Added Successfulyy";
                }
                else if(qry == 2)
                {
                    errMsg.Text = "Maximum Number of Semesters Exists for the selected Course";
                }
            }

        }
    }
}