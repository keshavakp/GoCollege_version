using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCollege_BL;
using GoCollege_CL;
using GoCollege_DL;
using System.Data;


namespace GoCollege_BL
{
    //
    public class AdminBL
    {
        AdminDL objAdmiDL = new AdminDL();
        PasswordBL objPasswordBL = new PasswordBL();

        //Variables

        public DataView AdminLogin(string adminUN, string adminPWD)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                string encryptedPassword = objPasswordBL.GenerateHash(adminPWD);
                adminPWD = encryptedPassword;

                dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                if (dvMsg.Count.Equals(0))
                {
                    return dvMsg.Table.DefaultView;
                }
                conn.CommitTransaction();
                return dvMsg.Table.DefaultView;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return dvMsg.Table.DefaultView;

        }

        public int AdminEditDetails(long adminID, string adminUserName, string adminFullName, string adminEmailID, long adminMobileNo, string adminNewPassword)
        {
            DataView dvMsg = null;
            int isUpdated = 0;
            Connection conn = new Connection();

            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.AdminFetchForEditDetails(conn.con, conn.trans, adminID, adminUserName, adminFullName, adminEmailID, adminMobileNo, objPasswordBL.GenerateHash(adminNewPassword));

                if (dvMsg.Count.Equals(0))
                {
                    return 0;
                }
                else
                {
                    if(dvMsg[0]["AdminStatus"].ToString().Equals("R"))
                    {
                        isUpdated = objAdmiDL.AdminUpdateFirstLoginAdminDetails(conn.con, conn.trans, adminID, adminUserName, adminFullName, adminEmailID, adminMobileNo, objPasswordBL.GenerateHash(adminNewPassword));
                    }
                    else if(dvMsg[0]["AdminStatus"].ToString().Equals("A"))
                    {
                        isUpdated = objAdmiDL.AdminUpdateAdminDetails(conn.con, conn.trans, adminID, adminUserName, adminFullName, adminEmailID, adminMobileNo, objPasswordBL.GenerateHash(adminNewPassword));
                    }
                }

                if (isUpdated != 1)
                {
                    return isUpdated;
                }
                conn.CommitTransaction();
                return isUpdated; 

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return isUpdated;
        }

        public DataView FetchTypeOfUserForNotification()
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.FetchTypeOfUserForNotification(conn.con, conn.trans);

                if (dvMsg.Count.Equals(0))
                {
                    return dvMsg.Table.DefaultView;
                }
                conn.CommitTransaction();
                return dvMsg.Table.DefaultView;
            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return dvMsg.Table.DefaultView;

        }

        public int SendNotification(string notificationSubject, string notificationContent, DateTime notificationDateTime, long notificationTypeOfUser)
        {
            DataView dvMsg = null;
            int isInserted = 0;
            Connection conn = new Connection();

            try
            {
                conn.BeginTransaction();

                isInserted = objAdmiDL.SendNotification(conn.con, conn.trans, notificationSubject, notificationContent, notificationDateTime, notificationTypeOfUser);

                if (isInserted != 1)
                {
                    return isInserted;
                }
                conn.CommitTransaction();
                return isInserted;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return isInserted; 
        }

        public DataView AddStudent(string studentUSN, string studentName, long collegeID, long studentMobile, string studentEmail, string studentAddress, long courseID, long semID, string studentPassword, string flag)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            int isStudentAdded = 0;


            try
            {
                conn.BeginTransaction();
                //checkfor duplication
                dvMsg = objAdmiDL.FetchStudentForDuplicationCheck(conn.con, conn.trans, studentUSN, studentName, collegeID, courseID, studentEmail, studentMobile);

                if(flag.Equals("AdminAdd"))
                {
                    if (!dvMsg.Count.Equals(0))
                    {
                        return dvMsg.Table.DefaultView;
                    }
                    else
                    {
                        conn.CommitTransaction();
                        //int isStudentAddedStudentTable = objAdmiDL.AddStudent(studentUSN, studentName, collegeID, studentMobile, studentAddress, courseID, semID, objPasswordBL.GenerateHash(adminNewPassword), flag);
                    }
                }
                else if (flag.Equals("AdminEdit"))
                {


                }
                else if (flag.Equals("AdminDelete"))
                {

                }

               
                
                return dvMsg.Table.DefaultView;
            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return dvMsg.Table.DefaultView;
        }

    }

}
