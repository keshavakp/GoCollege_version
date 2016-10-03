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
    public class FacultyBL
    {
        FacultyDL objFacultyDL = new FacultyDL();
        PasswordBL objPasswordBL = new PasswordBL();

        //
        public DataView FetchAllFacultyForGrid(long adminID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objFacultyDL.FetchAllFacultyForGrid(conn.con, conn.trans, adminID);
                            

                //Check
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
        

        //Add new 
        public int AddFaculty(string facultyCode,string facultyPassword, long colegeID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            int qryresult = 0;

            try
            {
                conn.BeginTransaction();

                dvMsg = objFacultyDL.FetchForExistingFacultyCode(conn.con, conn.trans,facultyCode,  colegeID);
                            

                //Check
                if (!dvMsg.Count.Equals(0))
                {
                    conn.CommitTransaction();
                    qryresult = -1;
                    return qryresult;

                }
                else
                {
                    qryresult = objFacultyDL.AddNewFaculty(conn.con, conn.trans, facultyCode, objPasswordBL.GenerateHash(facultyPassword), colegeID);

                    if (qryresult == 0)
                    {
                        conn.RollbackTransaction();
                        return qryresult;
                    }

                }

                conn.CommitTransaction();
                return qryresult;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }

            return qryresult;
        }
    }
}
