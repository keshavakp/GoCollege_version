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
    public partial class FacultyHome : System.Web.UI.Page
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

        protected void BindFacultyGrid()
        {
            DataView dv = new DataView();

         //   dv = objFacultyBL.FetchAllFacultyForGrid(long.Parse(Session["UserID"].ToString()));

            if (!dv.Count.Equals(0))
            {

            }

        }
    }
}