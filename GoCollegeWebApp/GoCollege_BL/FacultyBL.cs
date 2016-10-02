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
    }
}
