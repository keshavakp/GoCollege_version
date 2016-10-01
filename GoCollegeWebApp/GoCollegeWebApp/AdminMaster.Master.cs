using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoCollegeWebApp
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserID"] == null)
            //{
            //    Response.Redirect("AdminLogin.aspx");
            //}
            //else
            //{
            //    hfCollegeID.Value = Session["CollegeID"].ToString();
            //    hfUserID.Value = Session["UserID"].ToString();
            //    hfUserName.Value = Session["UserName"].ToString();
            //    hfUserType.Value = Session["UserType"].ToString();

            //    LoadMenus();

            //    SetSessions();
            //}

            if (Session["CollegeID"] != null)
            {
                hfCollegeID.Value = Session["CollegeID"].ToString();
            }

        }


        protected void LoadMenus()
        {
            if (hfUserType.Value == "A")
            {

            }
            else if (hfUserType.Value == "F")
            { 
            
            }
            else if (hfUserType.Value == "S")
            {
 
            }
        }

        protected void SetSessions()
        {
            Session["CollegeID"] = hfCollegeID.Value;
            Session["UserID"] = hfUserID.Value;
            Session["UserName"] = hfUserName.Value;
            Session["UserType"] = hfUserType.Value;
        }

        /* Menu IDs*/
         



    }
}