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


        public DataView AddStudentTest(string studentUSN, string studentName, long collegeID, long studentMobile, string studentEmail, string studentAddress, long courseID, long semID, string studentPassword, string flag)
        {

            DataView dvMsg = null;
            Connection conn = new Connection();
            int isStudentAdded = 0;

            try
            {
                conn.BeginTransaction();
                //checkfor duplication
                dvMsg = objStudentBL.FetchStudentForDuplicationCheck(conn.con, conn.trans, studentUSN, studentName, collegeID, courseID, studentEmail, studentMobile);

                if (flag.Equals("AdminAdd"))
                {
                    if (!dvMsg.Count.Equals(0))
                    {
                        return dvMsg.Table.DefaultView;
                    }
                    else
                    {
                        conn.CommitTransaction();
                        //int isStudentAddedStudentTable = objStudentBL.AddStudent(studentUSN, studentName, collegeID, studentMobile, studentAddress, courseID, semID, objPasswordBL.GenerateHash(adminNewPassword), flag);
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

    }
}
