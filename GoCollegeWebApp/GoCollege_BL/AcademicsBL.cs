using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GoCollege_DL;
using GoCollege_CL;

namespace GoCollege_BL
{
     
    class AcademicsBL
    {
        AdminDL objAdminDL = new AdminDL();
        AcademicsDL objAcademicsDL = new AcademicsDL();

        //Insert New Course
        public int AddCourse(string cName, string cShortName, Int16 cTotalSems)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                int qryResult = 0,chkExisting;

                dvMsg = objAcademicsDL.FetchForExistingCourseName(conn.con,conn.trans, cName);

                if (dvMsg.Count != 0)
                {
                    return -1;
                }

                else
                {
                    qryResult = objAcademicsDL.AddCourse(conn.con, conn.trans, cName, cShortName, cTotalSems);
                }

                //dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                if (qryResult == 0)
                {
                    conn.CommitTransaction();
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
       
        //Fetch All Course Details
        public DataView FetchAllCourse(Int64 adminID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAcademicsDL.FetchAllCourse(conn.con, conn.trans, adminID);

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

    }
}
