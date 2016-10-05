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
        

        //Fetch For Edit
        public DataView GetFacultyDetailsForEdit(long facultyID)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objFacultyDL.GetFacultyDetailsForEdit(conn.con, conn.trans, facultyID);


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
        
        //Check for Existing
        public int CheckForExistingMobileAndEmail(long facultyID, long facultyMobile, string facultyEmail)
        {
            DataView dvMsg = null;
            DataView dvMsg1 = null;

            Connection conn = new Connection();
            int qry = 0;
            try
            {
                conn.BeginTransaction();

                dvMsg = objFacultyDL.FetchForExistingMobile(conn.con, conn.trans, facultyID, facultyMobile);

                dvMsg1 = objFacultyDL.FetchForExistingEmail(conn.con, conn.trans, facultyID, facultyEmail);

                //Check 
                if (!dvMsg.Count.Equals(0) && !dvMsg1.Count.Equals(0))
                {
                    conn.CommitTransaction();
                    qry = 1;
                    return qry;
                }
                //Mobile
                else if (!dvMsg.Count.Equals(0))
                {
                    conn.CommitTransaction();
                    qry = 2;
                    return qry;
                }
                //Email
                else if (!dvMsg1.Count.Equals(0))
                {
                    conn.CommitTransaction();
                    qry = 3;
                    return qry;
                }

                conn.RollbackTransaction();
                return qry;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return qry;

        }

        //Edit Udpate
        public int EditUpdateFaculty(long facultyID, string facultyCode, string facultyName, long facultyMobile, string facultyEmail, string facultyAddress)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            int qryresult = 0;

            try
            {
                conn.BeginTransaction();

               // dvMsg = objFacultyDL.FetchForExistingFacultyCode(conn.con, conn.trans, facultyCode, colegeID);

                qryresult = objFacultyDL.EditUpdateFaculty(conn.con, conn.trans, facultyID, facultyCode, facultyName, facultyMobile, facultyEmail, facultyAddress);

                //Check
                if (qryresult == 0)
                {
                    conn.RollbackTransaction();
                    return qryresult;

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
        
        //Delete Faculty
        public int DeleteFaculty(long facultyID)
        {

            DataView dvMsg = null;
            Connection conn = new Connection();
            int qryresult = 0;

            try
            {
                conn.BeginTransaction();

                qryresult = objFacultyDL.DeleteFaculty(conn.con, conn.trans, facultyID);

                if (qryresult == 0)
                {
                    conn.RollbackTransaction();
                    return qryresult;
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
