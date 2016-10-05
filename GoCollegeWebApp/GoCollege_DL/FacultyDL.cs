using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCollege_CL;
using System.Data;
using System.Data.SqlClient;

namespace GoCollege_DL
{
    public class FacultyDL
    {
        //Fetch All Faculty Details
        public DataView FetchAllFacultyForGrid(SqlConnection con, SqlTransaction trans, long adminID)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "select * from tblFaculty where FacultyStatus in ('R','A') and CollegeID in (select CollegeID from tblAdmin where AdminID=@AdminID)";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@AdminID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = adminID;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {

            }

            return MyDataSet.Tables[0].DefaultView;
        }

        // Fetch for Edit
        public DataView GetFacultyDetailsForEdit(SqlConnection con, SqlTransaction trans, long faculyID)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "select * from tblFaculty where FacultyStatus in ('R','A') and FacultyID=@FacultyID";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@FacultyID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = faculyID;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {

            }

            return MyDataSet.Tables[0].DefaultView;
        }

        //Fetch for Existing Mobile
        public DataView FetchForExistingMobile(SqlConnection con, SqlTransaction trans, long faculyID, long facultyMobile)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "select * from tblFaculty where FacultyStatus in ('R','A') and FacultyID not in (@FacultyID) and FacultyMobile=@FacultyMobile";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@FacultyID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = faculyID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FacultyMobile", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyMobile;
                cmd.Parameters.Add(param);


                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {

            }

            return MyDataSet.Tables[0].DefaultView;
        }


        //Fetch for Existing Email
        public DataView FetchForExistingEmail(SqlConnection con, SqlTransaction trans, long faculyID, string facultyEmail)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "select * from tblFaculty where FacultyStatus in ('R','A') and FacultyID not in (@FacultyID) and FacultyEmail=@FacultyEmail";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@FacultyID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = faculyID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FacultyMobile", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyEmail;
                cmd.Parameters.Add(param);


                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {

            }

            return MyDataSet.Tables[0].DefaultView;
        }


        //FetchFor Existing Faculty Code

        public DataView FetchForExistingFacultyCode(SqlConnection con,SqlTransaction trans ,string facultyCode, long collegeID)
        {
             DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "select * from tblFaculty where FacultyCode=@FacultyCode and CollegeID=@CollegeID";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = collegeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FacultyCode", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyCode;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {

            }

            return MyDataSet.Tables[0].DefaultView;
        }
        
        //Add new Faculty Details  and / or check for duplicatte

        public int AddNewFaculty(SqlConnection con,SqlTransaction trans ,string facultyCode, string facultyPassword,long collegeID)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            int qryresult = 0;
            try
            {

                qry = "insert into tblFaculty(FacultyCode,CollegeID,FacultyPassword,FacultyStatus) values (@FacultyCode,@CollegeID, @FacultyPassword ,@FacultyStatus)";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@FacultyCode", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyCode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FacultyPassword", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyPassword;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FacultyStatus", SqlDbType.Char, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = "R";
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = collegeID;
                cmd.Parameters.Add(param);


                qryresult = cmd.ExecuteNonQuery();

                //MyDataAdapter = new SqlDataAdapter(cmd);
                //MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {

            }

            return qryresult;
        }

        //Delete Faculty
        public int DeleteFaculty(SqlConnection con, SqlTransaction trans, long facultyID)
        {

            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            int qryresult = 0;
            try
            {

                qry = "delete from tblFaculty where FacultyID= @FacultyID";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@FacultyID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyID;
                cmd.Parameters.Add(param);

                qryresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }

            return qryresult;
        }

        //
        public int EditUpdateFaculty(SqlConnection con, SqlTransaction trans, long facultyID, string facultyCode, string facultyName, long facultyMobile,
            string facultyEmail, string facultyAddress)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            int qryresult = 0;
            try
            {

                qry = "update tblFaculty set FacultyCode=@ where FacultyID=@FacultyID ";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@FacultyID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyID;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FacultyCode", SqlDbType.VarChar,50);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyCode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FacultyName", SqlDbType.VarChar,150);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyName;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FacultyMobile", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyMobile;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FacultyEmail", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyEmail;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@FacultyAddress", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = facultyAddress;
                cmd.Parameters.Add(param);



                qryresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }

            return qryresult;
        }
        
    }
}
