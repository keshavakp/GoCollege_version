using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCollege_CL;
using GoCollege_DL;
using System.Data;
using System.Data.SqlClient;

namespace GoCollege_DL
{
    public class AcademicsDL
    {

        //Insert New Course
        public int AddCourse(SqlConnection con,SqlTransaction trans, string cName, string cShortName, Int16 cTotalSems)
        {

            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "Insert into Course values(@CourseName,@CourseShortName,@TotalSems,@Status)";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@CourseName", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = cName;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@CourseShortName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = cShortName;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@TotalSems", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = cTotalSems;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@Status", SqlDbType.Char, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = "A";
                cmd.Parameters.Add(param);          

                int retValue = 0;

                retValue = cmd.ExecuteNonQuery();
                return retValue;
            }

            catch (SqlException SqlEx)
            {

            }
            return 0;  
 
        }

        //Check For Existing COurse
        public DataView FetchForExistingCourseName(SqlConnection con, SqlTransaction trans, string cName)
        {
            
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "select * from tblCourse where CourseName = @CourseName and CourseStatus='A' ";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@CourseName", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = cName;
                cmd.Parameters.Add(param);
                
                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {
 
            }

            return MyDataSet.Tables[0].DefaultView;   

        }

        //Fetch All Course Details
        public DataView FetchAllCourse(SqlConnection con, SqlTransaction trans, Int64 adminID)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = "select * from tblCourse where CollegeID in (select CollegeID from tblAdmin where AdminID=@adminID)";

                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@CourseName", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = cName;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch (Exception ex)
            {

            }

            return MyDataSet.Tables[0].DefaultView;  
 
        }

    }
}
