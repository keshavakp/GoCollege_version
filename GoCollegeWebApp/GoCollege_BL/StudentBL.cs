using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCollege_DL;
using GoCollege_CL;
using System.Data;

namespace GoCollege_BL
{
    public class StudentBL
    {

        StudentDL objStudentBL = new StudentDL();
        PasswordBL objPasswordBL = new PasswordBL();

        //Student Add By Admin
        public int AddStudent(string studentUSN,  long collegeID,long courseID, long semID, string studentPassword,string flag)
        {
           
            DataView dvMsg = null;
            Connection conn = new Connection();
            int isStudentAdded = 0;

            try
            {
                conn.BeginTransaction();
                //checkfor duplication

                if (flag.Equals("AdminAdd"))
                {
                    dvMsg = objStudentBL.FetchForExistingStudentUSN(conn.con, conn.trans, studentUSN, collegeID);
                    if (!dvMsg.Count.Equals(0))
                    {
                        conn.RollbackTransaction();
                        return -1;
                    }
                    else
                    {
                        //conn.CommitTransaction();

                        int isStudentAddedStudentTable =0;
                        isStudentAddedStudentTable= objStudentBL.AddStudent(conn.con,conn.trans, studentUSN, collegeID, courseID, semID, objPasswordBL.GenerateHash(studentPassword));

                        if (isStudentAddedStudentTable == 1)
                        {
                            conn.CommitTransaction();
                            return isStudentAddedStudentTable;
                        }
                        else
                        {
                            conn.RollbackTransaction();
                            return isStudentAddedStudentTable;
                        }

                    }
                }
                else if (flag.Equals("AdminEdit"))
                {


                }
                else if (flag.Equals("AdminDelete"))
                {

                }
                return isStudentAdded;
            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return isStudentAdded;
        }


        public int EditUpdateStudent(long studentID, long collegeID, string studentUSN, string studentName, string studentEmail, long studentMobile, string studentAddress, long courseID, long semID, string studentPassword, string studentStatus)
        {

            DataView dvMsg = null;
            Connection conn = new Connection();
            int isStudentUpdated= 0;

            try
            {
                conn.BeginTransaction();         

                isStudentUpdated = objStudentBL.EditUpdateStudent(conn.con, conn.trans,studentID,collegeID,  studentUSN, studentName, studentEmail,studentMobile,studentAddress, courseID, semID, objPasswordBL.GenerateHash(studentPassword), studentStatus);
                
                if (isStudentUpdated == 0)
                {
                    conn.RollbackTransaction();
                }

                conn.CommitTransaction();
                return isStudentUpdated;
            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return isStudentUpdated;
        }


        public DataView FetchAllStudentForGrid(long collegeID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            int isStudentAdded = 0;

            try
            {
                conn.BeginTransaction();

                dvMsg = objStudentBL.FetchAllStudentForGrid(conn.con, conn.trans, collegeID);

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

        //Fetch Student For Student Details using StudentID

        public DataView FetchStudentDetailsByStudentID(long studentID,long collegeID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
          //  int isStudentAdded = 0;

            try
            {
                conn.BeginTransaction();

                dvMsg = objStudentBL.FetchStudentDetailsByStudentID(conn.con, conn.trans,studentID, collegeID);

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

        public DataView ChkForExistingContactDetails(long studentID,long collegeID,long studentMobile,string studentEmail)            
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
          //  int isStudentAdded = 0;

            try
            {
                conn.BeginTransaction();

                dvMsg = objStudentBL.FetchForExistingStudentContactDetails(conn.con, conn.trans, studentID, collegeID, studentMobile, studentEmail);

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

    }
}
