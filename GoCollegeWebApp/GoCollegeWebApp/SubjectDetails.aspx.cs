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
    public partial class SubjectDetails : System.Web.UI.Page
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
                    BindSubjects();
                }
            }
        }


        //BindGRid

        protected void BindSubjects()
        {
            divDataGrid.Visible = true;

            divAdd.Visible = false;
            divEdit.Visible = false;

            DataView dv = new DataView();
            dv = objAdminBL.FetchAllSubjectsForGrid(long.Parse(Session["CollegeID"].ToString()));

            if (!dv.Count.Equals(0))
            {
                dgSubjectDetails.DataSource = dv;
                dgSubjectDetails.DataBind();
            }
        }


        //Add NEw
        protected void lnkAddNewSubject(object sender,EventArgs e)
        {
            divDataGrid.Visible = false;
            divAdd.Visible = true;
            divEdit.Visible= false;
        }

        //View All
        protected void lnkViewAll(object sender,EventArgs e)
        {
            BindSubjects();
        }

        //Edit Command
        protected void btnSubjecttEdit_Command(object sender, CommandEventArgs e)
        {
            divDataGrid.Visible = false;
            divAdd.Visible = false;
            divEdit.Visible = true;
        }

        //Delete
        protected void btnSubjectDelete_Command(object sender, CommandEventArgs e)
        {
            int qry = 0;

            qry = objAdminBL.DeleteSubjectBySubjectID(long.Parse(e.CommandName.ToString()));

            if (qry == 1)
            {
                errMsg.Text = "Subject Deleted Successfully";
                BindSubjects();
            }
        }
    }
}