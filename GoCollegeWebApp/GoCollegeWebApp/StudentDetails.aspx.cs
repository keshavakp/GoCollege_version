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
    public partial class StudentDetails : System.Web.UI.Page
    {
        AdminBL objAdminBL = new AdminBL();
        StudentBL objStudentBL = new StudentBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AdminID"] == null)
                {
                    Response.Redirect("AdminLogin.apsx");
                }
                else
                {
                    BindStudentGrid();
                }
            }
        }

        public void BindStudentGrid()
        {
            divAdd.Visible = false;
            divDataGrid.Visible = true;

            divEdit.Visible = false;
            DataView dv = new DataView();
            dv= objStudentBL.FetchAllStudentForGrid(long.Parse(Session["CollegeID"].ToString()));

            if (!dv.Count.Equals(0))
            {
                dgStudentDetails.DataSource = dv;
                dgStudentDetails.DataBind();
            } 
        }

        //edit click Bind Data to Student Edit FOrm
        protected void btnStudentEdit_Command(object sender, CommandEventArgs e)
        {
            divAdd.Visible = false;
            divDataGrid.Visible = false;
            divEdit.Visible = true;

            DataView dv = new DataView();
            dv = objStudentBL.FetchStudentDetailsByStudentID(long.Parse(e.CommandName.ToString()), long.Parse(Session["CollegeID"].ToString()));

            if (!dv.Count.Equals(0))
            {
                txteditStudentUSN.Text = dv[0]["StudentUSN"].ToString();
                txteditStudentName.Text = dv[0]["StudentName"].ToString();
                txteditStudentMobile.Text = dv[0]["StudentMobile"].ToString();
                txteditStudentEmail.Text = dv[0]["StudentEmail"].ToString();
                txteditStudentAddress.Text = dv[0]["StudentAddress"].ToString();
            }          
        }

        //Delete click
        protected void btnStudentDelete_Command(object sender, CommandEventArgs e)
        {

        }

        //Add new click
        protected void lnkAddNewStudent(object sender, EventArgs e)
        {
            BindCourse();

            divEdit.Visible = false;
            divAdd.Visible = true;
            divDataGrid.Visible = false;

        }

        //View All click
        protected void lnkViewAll(object sender, EventArgs e)
        {
            BindStudentGrid();
        }

        //Bind Course List to Grid
        public void BindCourse()
        {
            DataView dv = new DataView();

            dv = objAdminBL.FetchAllCourse(long.Parse(Session["AdminID"].ToString()));

            ddlstudentCourse.DataSource = dv;

            ddlstudentCourse.DataTextField = "CourseName";
            ddlstudentCourse.DataValueField = "CourseID";
            ddlstudentCourse.DataBind();
            //ddlstudentCourse.
            ddlstudentCourse.Items.Insert(0, new ListItem(" Select ", "0")); 
        }

        //Bind Sem
        protected void ddlstudentSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (long.Parse(ddlstudentCourse.SelectedValue.ToString()) == 0)
            {
                ddlstudentSemester.Items.Clear();
            }
            else
            {
              DataView dv = new DataView();
              
              dv =  objAdminBL.FetchAllSemsByCourseID(long.Parse(ddlstudentCourse.SelectedValue.ToString()));


              ddlstudentSemester.DataSource = dv;
              ddlstudentSemester.DataTextField = "SemNumber";
              ddlstudentSemester.DataValueField = "SemID";
              ddlstudentSemester.DataBind();
              ddlstudentSemester.Items.Insert(0, new ListItem(" Select ", "0")); 
              
            } 
        }

        // Add Submit Click
        protected void btnStudentAddSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int chkqry=0;
                chkqry = objStudentBL.AddStudent(txtstudentUSN.Text.ToString(), long.Parse(Session["CollegeID"].ToString()), long.Parse(ddlstudentCourse.SelectedValue.ToString()), long.Parse(ddlstudentSemester.SelectedValue.ToString()), txtstudentPassword.Text.ToString(), "AdminAdd");
 
            }
        }


        //Reset All
        public void ResetAll()
        {
            //Add Form Reset
            txtstudentPassword.Text = "";
            txtstudentUSN.Text = "";
        }
        
        //Edit Update Student Click
        protected void btneditUpdate_Click(object sender, EventArgs e)
        { 

        }





    }   
}