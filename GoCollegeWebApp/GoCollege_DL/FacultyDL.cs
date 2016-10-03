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



        
    }
}
