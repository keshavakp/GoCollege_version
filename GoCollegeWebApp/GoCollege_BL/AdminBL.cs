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

    public class AdminBL
    {
          AdminDL objAdmiDL = new AdminDL();

        PasswordBL objPasswordBL = new PasswordBL();
        
        //Variables

        public DataView AdminLogin(string adminUN,string adminPWD)
        {
               DataView dvMsg=null;
               Connection conn = new Connection();
               try
               {
                   conn.BeginTransaction();

                  dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, objPasswordBL.GenerateHash(adminPWD));

                   if (dvMsg.Count.Equals(0))
                   {
                       conn.CommitTransaction();

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


        //Check for Existing Email ID and Mobile Number
        public DataView ChkForExisting()
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.ChkForExisting(conn.con, conn.trans);

                if (dvMsg.Count.Equals(0))
                {
                    conn.CommitTransaction();

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

        //Check for Existing Email ID.Mobile and Phone Number //College Details
        public DataView ChkForExistingCollegeDetails()
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.ChkForExisting(conn.con, conn.trans);

                if (dvMsg.Count.Equals(0))
                {
                    conn.CommitTransaction();

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


        //Code added By Mayur
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
                    if (dvMsg[0]["AdminStatus"].ToString().Equals("R"))
                    {
                        isUpdated = objAdmiDL.AdminUpdateFirstLoginAdminDetails(conn.con, conn.trans, adminID, adminUserName, adminFullName, adminEmailID, adminMobileNo, objPasswordBL.GenerateHash(adminNewPassword));
                    }
                    else if (dvMsg[0]["AdminStatus"].ToString().Equals("A"))
                    {
                        isUpdated = objAdmiDL.AdminUpdateAdminDetails(conn.con, conn.trans, adminID, adminUserName, adminFullName, adminEmailID, adminMobileNo, objPasswordBL.GenerateHash(adminNewPassword));
                    }
                }

                if (isUpdated != 1)
                {
                    conn.RollbackTransaction();
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


        //End




        //Update Admin Details
        public int EditAdmin(string adminUN, string adminName, string adminEmail, Int64 adminMobile, string adminPWD)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                string encryptedPassword = objPasswordBL.GenerateHash(adminPWD);
                adminPWD = encryptedPassword;

                int qryResult = 0;

                qryResult = objAdmiDL.EditAdmin(conn.con, conn.trans, adminUN, adminName, adminEmail, adminMobile, adminPWD);

                //dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                if (qryResult== 0)
                {
                    conn.RollbackTransaction();
                    return qryResult;

                }

                conn.CommitTransaction();

                return 1;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
          //  return dvMsg.Table.DefaultView;
            return 0;
        }


        //Fetch Collge Details
        public DataView FetchCollgeDetails(Int64 adminID, string adminUN)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.FetchCollegeDetails(conn.con, conn.trans,adminID, adminUN);

                if (dvMsg.Count.Equals(0))
                {
                    conn.RollbackTransaction();

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

        //Update College Details
        public int UpdateCollegeDetails(string clgCode,string clgName,string clgEmail,Int64 clgPhone,Int64 clgMobile,string clgAddress)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();
                             

                int qryResult = 0;

                qryResult = objAdmiDL.UpdateCollegeDetails(conn.con, conn.trans, clgCode, clgName, clgEmail, clgPhone, clgMobile, clgAddress);

                //dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                if (qryResult == 0)
                {
                    conn.RollbackTransaction();
                    return qryResult;

                }

                conn.CommitTransaction();

                return 1;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            //  return dvMsg.Table.DefaultView;
            return 0;

            
        }

      

        //Insert New Course
        public int AddCourse(string cName, string cShortName, Int16 cTotalSems,Int64 CollegeID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                int qryResult = 0;

                dvMsg = objAdmiDL.FetchForExistingCourseName(conn.con, conn.trans, cName, CollegeID);

                if (dvMsg.Count != 0)
                {
                    qryResult = -1;
                }

                else
                {
                    qryResult = objAdmiDL.AddCourse(conn.con, conn.trans, cName, cShortName, cTotalSems, CollegeID);
                }

                if (qryResult == 1)
                {
                    conn.CommitTransaction();         
                    return qryResult;

                }
                else if (qryResult == -1)
                {
                    conn.RollbackTransaction();
                    return qryResult;
                }


                conn.CommitTransaction();
                return qryResult;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            //  return dvMsg.Table.DefaultView;
            return 0;
        }

        //Fetch All Course Details
        public DataView FetchAllCourse(Int64 adminID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.FetchAllCourse(conn.con, conn.trans, adminID);

                if (dvMsg.Count.Equals(0))
                {
                    conn.RollbackTransaction();
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

        //Delete Course Details
         //Delete Course
        public int DeleteCourse(Int64 courseID)
        {
            DataView dvMsg = null;
            int isdeleted = 0;
            Connection conn = new Connection();

            try
            {
                conn.BeginTransaction();
                isdeleted = objAdmiDL.DeleteCourse(conn.con,conn.trans,courseID);

                if (isdeleted == 0)
                {
                    conn.RollbackTransaction();
                    return isdeleted;
                }
                conn.CommitTransaction();
                return isdeleted;


            }
            catch (Exception ex)
            {
 
            }

            return isdeleted;

        }



        //Fetch Course For Edit
        public DataView FetchCourseForEdit(Int64 courseID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.FetchCourseForEdit(conn.con, conn.trans, courseID);

                if (dvMsg.Count.Equals(0))
                {
                    conn.RollbackTransaction();
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

        //Update Course
        public int UpdateCourseDetails(Int64 courseID, string cName, string cShortName, Int16 cTotalSems, Int64 CollegeID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();


                int qryResult = 0;

                qryResult = objAdmiDL.UpdateCourseDetails(conn.con, conn.trans, courseID, cName, cShortName, cTotalSems, CollegeID);

                //dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                if (qryResult == 0)
                {
                    conn.RollbackTransaction();
                    return qryResult;

                }

                conn.CommitTransaction();

                return 1;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            //  return dvMsg.Table.DefaultView;
            return 0;

        }
    }

}
