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
                    BindSemester();
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
                divAdd.Visible = false;
                divDataGrid.Visible = true;
                divEdit.Visible = false;

                DataView dv = new DataView();
                dv = objAdminBL.FetchAllSemesterForGrid(long.Parse(Session["CollegeID"].ToString()));
                dgSemestereDetails.DataSource = dv;
                dgSemestereDetails.DataBind();
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
            ddlCourse.Items.Insert(0, new ListItem(" Select ", "0"));
        }

        //Add new click
        protected void lnkAddNewSemester(object sender, EventArgs e)
        {
            BindCourse();
           // BindSemester();
            divEdit.Visible = false;
           divAdd.Visible = true;
           divDataGrid.Visible = false;

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
   
        // Edit Command
        protected void btnSemestertEdit_Command(object sender, CommandEventArgs e)
        {
            divAdd.Visible = false;
            divDataGrid.Visible = false;
            divEdit.Visible = true;

            hfSemID.Value = e.CommandName.ToString();

            DataView dv = new DataView();
            dv = objAdminBL.FetchSemesterForEdit(long.Parse(e.CommandName.ToString()));

            DataView dvCourse = new DataView();
            dvCourse =  objAdminBL.FetchAllCourse(long.Parse(Session["UserID"].ToString()));           

            //ddlEditCourse
            ddlEditCourse.DataSource = dvCourse;
            ddlEditCourse.DataTextField = "CourseName";
            ddlEditCourse.DataValueField = "CourseID";
            ddlEditCourse.DataBind();
            ddlEditCourse.Items.Insert(0, new ListItem(" Select ", "0"));

            long courseID = 0;
                                    
            if (!dv.Count.Equals(0))     
            {
                txtEditSemNum.Text = dv[0]["SemNumber"].ToString();
                courseID = long.Parse(dv[0]["CourseID"].ToString());
                ddlEditCourse.SelectedValue = courseID.ToString();
                txtEditSemTotalSubjects.Text = dv[0]["SemTotalSubjects"].ToString();
            }

        }

        //Edit Update 
        protected void btnEditUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int qry = 0;

                qry = objAdminBL.EditUpdateSemester(long.Parse(hfSemID.Value.ToString()),
                    int.Parse(txtEditSemNum.Text.ToString()), long.Parse(ddlEditCourse.SelectedValue.ToString()),long.Parse(txtEditSemTotalSubjects.Text.ToString()) );

                if (qry == 1)
                {
                    errMsg.Text = "Semester Details Updated Successfully";
                    BindSemester();
                }
                else
                {

                }
            }
        }

        
        // Delete Command
        protected void btnSemesterDelete_Command(object sender, CommandEventArgs e)
        {
            int qry = 0;

            qry = objAdminBL.DeleteSemester(long.Parse(e.CommandName.ToString()));

            if (qry == 1)
            {
                errMsg.Text = "Semester Deleted Successfully";

                BindSemester();
            }

        }

        
    }
}