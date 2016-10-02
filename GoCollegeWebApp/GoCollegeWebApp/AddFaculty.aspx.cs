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
    public partial class AddFaculty : System.Web.UI.Page
    {
        FacultyBL objFacultyBL = new FacultyBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                BindFacultyGrid();
            }

        }



        //lnk Add Click
        protected void lnkAddNewFaculty(object sender, EventArgs e)
        {

        }

        //lnk View All Click
        protected void lnkViewAll(object sender, EventArgs e)
        {

        }

        //
        protected void BindFacultyGrid()
        {
            DataView dv = new DataView();

            dv = objFacultyBL.FetchAllFacultyForGrid(long.Parse(Session["UserID"].ToString()));

            if (!dv.Count.Equals(0))
            {

            }

        }
    }
}