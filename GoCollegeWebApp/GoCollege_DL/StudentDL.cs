using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;



namespace GoCollege_DL
{
    public class StudentDL
    {

        //Fetch FOr Existing USN
        public DataView FetchForExistingStudentUSN(SqlConnection con, SqlTransaction trans, string studentUSN, long collegeID)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblStudent where StudentUSN = @StudentUSN and CollegeID=@CollegeID ";
                    cmd = new SqlCommand(qry, con, trans);
                    cmd.CommandType = CommandType.Text;
                    SqlParameter param;

                    param = new SqlParameter("@StudentUSN", SqlDbType.VarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = studentUSN;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = collegeID;
                    cmd.Parameters.Add(param);

                    MyDataAdapter = new SqlDataAdapter(cmd);
                    MyDataAdapter.Fill(MyDataSet);
                
            }

            catch (SqlException SqlEx)
            {

            }
            return MyDataSet.Tables[0].DefaultView;

        }

        public DataView FetchStudentForDuplicationCheck(SqlConnection con, SqlTransaction trans, string studentUserName, string studentName, long collegeID, long courseID, string studentEmail, long studentMobile)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                if (studentUserName != "" || studentUserName != null)
                {
                    qry = "Select StudentID from tblStudent whereStudentUSN = @StudentUserName";
                    cmd = new SqlCommand(qry, con, trans);
                    cmd.CommandType = CommandType.Text;
                    SqlParameter param;

                    param = new SqlParameter("@StudentUserName", SqlDbType.BigInt, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = studentUserName;
                    cmd.Parameters.Add(param);

                    MyDataAdapter = new SqlDataAdapter(cmd);
                    MyDataAdapter.Fill(MyDataSet);
                }
                else
                {
                    qry = "Select StudentID from tblStudent where StudentMobile=@StudentMobile and CollegeID = @CollegeID";
                    cmd = new SqlCommand(qry, con, trans);
                    cmd.CommandType = CommandType.Text;
                    SqlParameter param;

                    // parameter for UserName column
                    param = new SqlParameter("@StudentMobile", SqlDbType.BigInt, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = studentMobile;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StudentUserName", SqlDbType.BigInt, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = studentUserName;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@CollegeID", SqlDbType.BigInt, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = collegeID;
                    cmd.Parameters.Add(param);

                    MyDataAdapter = new SqlDataAdapter(cmd);
                    MyDataAdapter.Fill(MyDataSet);
                }
            }

            catch (SqlException SqlEx)
            {

            }
            return MyDataSet.Tables[0].DefaultView;
        }

        public int AddStudent(SqlConnection con, SqlTransaction trans, string studentUSN,long collegeID, long courseID, long semID, string studentPassword)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            int isUpdated = 0;

            try
            {
                qry = "INSERT INTO tblStudent (StudentUSN,CollegeID,CourseID,SemID,StudentPassword,StudentStatus) values (@StudentUSN,@CollegeID,@CourseID,@SemID,@StudentPassword,@StudentStatus) ";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@StudentUSN", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = studentUSN;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = collegeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CourseID", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = courseID;
                cmd.Parameters.Add(param);
                
                param = new SqlParameter("@SemID", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = semID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentPassword", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = studentPassword;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@StudentStatus", SqlDbType.Char, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = 'R';
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);

                isUpdated = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }

            return isUpdated;
        }

        //Update Student
        public int EditUpdateStudent(SqlConnection con, SqlTransaction trans, long studentID, long collegeID, string studentUSN, string studentName, string studentEmail, long studentMobile, string studentAddress, long courseID, long semID, string studentPassword, string studentStatus)
        {
            int isUpdated = 0;
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";

            try
            {
                qry = "UPDATE tblStudent SET StudentName=@StudentName, StudentEmail = @StudentEmail, StudentMobile = @StudentMobile, StudentPassword=@StudentPassword where StudentID = @StudentID and StudentUSN = @StudentUSN and CollegeID=@CollegeID";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = collegeID;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@StudentName", SqlDbType.VarChar, 150);
                param.Direction = ParameterDirection.Input;
                param.Value = studentName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentEmail", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = studentEmail;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentMobile", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = studentMobile;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@StudentAddress", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = studentAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = studentID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentUSN", SqlDbType.VarChar,50);
                param.Direction = ParameterDirection.Input;
                param.Value = studentUSN;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@CourseID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = courseID;
                cmd.Parameters.Add(param);
                
                param = new SqlParameter("@SemID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = studentID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentPassword", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value =  studentPassword;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentStatus", SqlDbType.Char, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = studentStatus;
                cmd.Parameters.Add(param);


                isUpdated = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }

            return isUpdated;
        }

        public int DeleteStudent(SqlConnection con, SqlTransaction trans,long studentID, string studentUserName, string CollegeID)
        {
            DataSet MyDataSet = new DataSet();
            SqlCommand cmd = null;
            string qry = "";
            int isStudentDeleted = 0;

            try
            {
                qry = "update tblStudent Set StudentStatus='D' where StudentID=@StudentID and CollegeID = @CollegeID";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@StudentUserName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = studentUserName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = CollegeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = CollegeID;
                cmd.Parameters.Add(param);


                //MyDataAdapter = new SqlDataAdapter(cmd);
                isStudentDeleted = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }

            return isStudentDeleted;
        }

        public DataView FetchAllStudentForGrid(SqlConnection con, SqlTransaction trans, long collegeID)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblStudent where CollegeID=@CollegeID ";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = collegeID;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);

            }

            catch (SqlException SqlEx)
            {

            }
            return MyDataSet.Tables[0].DefaultView;
        }

        //Fetch Student For Student Details using StudentID

        public DataView FetchStudentDetailsByStudentID(SqlConnection con, SqlTransaction trans, long studentID, long collegeID)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblStudent where CollegeID=@CollegeID and StudentID=@StudentID ";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = collegeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = studentID;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);

            }

            catch (SqlException SqlEx)
            {

            }
            return MyDataSet.Tables[0].DefaultView;
 
        }

        public DataView FetchForExistingStudentContactDetails(SqlConnection con, SqlTransaction trans, long studentID, long collegeID,long studentMobile,string studentEmail)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblStudent where StudentMobile =@StudentMobile or StudentEmail = @StudentEmail   ";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                param = new SqlParameter("@CollegeID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = collegeID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = studentID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentMobile", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = studentMobile;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StudentEmail", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = studentEmail;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);

            }

            catch (SqlException SqlEx)
            {

            }
            return MyDataSet.Tables[0].DefaultView;
        }
    }
}
