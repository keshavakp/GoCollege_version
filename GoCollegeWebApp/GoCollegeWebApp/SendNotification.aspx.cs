
using GoCollege_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoCollegeWebApp
{
    public partial class SendNotification : System.Web.UI.Page
    {
        AdminBL objadminBL = new AdminBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] != null || Session["AdminUserName"] != null)
            {
                //get list of users from DB
                if (!IsPostBack)
                {
                    DataView dv = new DataView();
                    dv = objadminBL.FetchTypeOfUserForNotification();

                    if (!dv.Count.Equals(0))
                    {
                        for (int i = 0; i < dv.Count; i++)
                        {
                            if (dv[i]["TypeOfUser"].ToString().Equals("A"))
                            {
                                ddlNotificationTo.Items.Add(new ListItem("All", dv[i]["TypeOfUserID"].ToString()));
                            }
                            else if (dv[i]["TypeOfUser"].ToString().Equals("T"))
                            {
                                ddlNotificationTo.Items.Add(new ListItem("Teacher", dv[i]["TypeOfUserID"].ToString()));
                            }
                            else
                            {
                                ddlNotificationTo.Items.Add(new ListItem("Student", dv[i]["TypeOfUserID"].ToString()));
                            }
                        }

                    }
                    else
                    {
                        //Show appropriate error message

                    }
                }
            }

        }

        protected void btnNotificationSubmit_Click(object sender, EventArgs e)
        {
            int isInserted = 0;
            DateTime currentDateTime = DateTime.Now;

            isInserted = objadminBL.SendNotification(txtNotificationSubject.Text.ToString(), txtNotificationMessage.Text.ToString(), currentDateTime, long.Parse(ddlNotificationTo.SelectedIndex.ToString()));

            if (isInserted != 1)
            {
                lblErrorMsg.Text = "Not Sent";
            }
            else
            {
                ddlNotificationTo.SelectedIndex = 0;
                txtNotificationMessage.Text = "";
                txtNotificationSubject.Text = "";
                lblErrorMsg.Text = "Notification Sent successfully";
            }
        }
    
    }
}