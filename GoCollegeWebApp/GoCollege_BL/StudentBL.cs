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
        public DataView AddStudent(string studentUSN, string studentName, long collegeID, long studentMobile, string studentEmail, string studentAddress, long courseID, long semID, string studentPassword, string flag)
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


        public void AddNewStudent(string studentUSN, long collegeID, long courseID, long semID, string studentPassword, string studentStatus)
        {
 
        }
    }
}
