using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace GoCollege_DL
{


    public class AdminDL
    {
        public DataView FetchAdminDetails(SqlConnection con, SqlTransaction trans, String adminUN, String adminPWD)
        { 
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblAdmin where AdminUserName=@UserName and AdminPassword=@Password and AdminStatus in('R','A')";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUN;
                cmd.Parameters.Add(param);

                // parameter for Password column
                param = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminPWD;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }

            catch (SqlException SqlEx)
            {
                
            }

            return MyDataSet.Tables[0].DefaultView;        
        }

        public DataView AdminFetchForEditDetails(SqlConnection con, SqlTransaction trans, long adminID, String adminUserName, String adminFullName, String adminEmailID, long adminMobileNo, String adminNewPassword)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";

            try
            {
                qry = "Select AdminStatus from tblAdmin where AdminUserName=@UserName and AdminID=@AdminID";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUserName;
                cmd.Parameters.Add(param);

                // parameter for Password column
                param = new SqlParameter("@AdminID", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminID;
                cmd.Parameters.Add(param);

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }

            catch (SqlException SqlEx)
            {

            }

            return MyDataSet.Tables[0].DefaultView;
        }

        public int AdminUpdateFirstLoginAdminDetails(SqlConnection con, SqlTransaction trans, long adminID, String adminUserName, String adminFullName, String adminEmailID, long adminMobileNo, String adminNewPassword)
        {
            DataSet MyDataSet = new DataSet();
            SqlCommand cmd = null;
            string qry = "";
            int isUpdated = 0;

            try
            {
                qry = "UPDATE tblAdmin SET AdminName=@AdminName, AdminEmail = @AdminEmail, AdminMobile = @AdminMobile, AdminStatus=@AdminStatus where AdminID = @AdminID and AdminUserName = @AdminUserName and AdminStatus = 'R'";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@AdminName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUserName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminEmail", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminEmailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminMobile", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminMobileNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminStatus", SqlDbType.Char, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = 'A';
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminID", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminUserName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUserName;
                cmd.Parameters.Add(param);

                //MyDataAdapter = new SqlDataAdapter(cmd);
                isUpdated = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }

            return isUpdated;
        }

        public int AdminUpdateAdminDetails(SqlConnection con, SqlTransaction trans, long adminID, String adminUserName, String adminFullName, String adminEmailID, long adminMobileNo, String adminNewPassword)
        {
            int isUpdated = 0;
            SqlCommand cmd = null;
            string qry = "";

            try
            {
                qry = "UPDATE tblAdmin SET AdminName=@AdminName, AdminEmail = @AdminEmail, AdminMobile = @AdminMobile where AdminID = @AdminID and AdminUserName = @AdminUserName";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@AdminName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUserName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminEmail", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminEmailID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminMobile", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminMobileNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminID", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminID;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@AdminUserName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUserName;
                cmd.Parameters.Add(param);

                isUpdated = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }

            return isUpdated;
        }
    
        public DataView FetchTypeOfUserForNotification(SqlConnection con, SqlTransaction trans)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblTypeOfUser";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;

                MyDataAdapter = new SqlDataAdapter(cmd);
                MyDataAdapter.Fill(MyDataSet);
            }

            catch (SqlException SqlEx)
            {

            }

            return MyDataSet.Tables[0].DefaultView;    
        }
    
        public int SendNotification(SqlConnection con, SqlTransaction trans, string notificationSubject, string notificationContent, DateTime notificationDateTime, long notificationTypeOfUser)
        {
            int isInserted = 0;
            SqlCommand cmd = null;
            string qry = "";

            try
            {
                qry = "insert into tblNotification (NotificationSubject, NotificationContent, NotificationDateTime, NotificationToTypeOfUser, NotificationStatus) values (@NotificationSubject, @NotificationContent, @NotificationDateTime, @NotificationTypeOfUser, 'I')";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@NotificationSubject", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = notificationSubject;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NotificationContent", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = notificationContent;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NotificationDateTime", SqlDbType.DateTime, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = notificationDateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@NotificationTypeOfUser", SqlDbType.BigInt, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = notificationTypeOfUser;
                cmd.Parameters.Add(param);

                isInserted = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }
            return isInserted;
        }

        public DataView FetchStudentForDuplicationCheck(SqlConnection con, SqlTransaction trans, string studentUserName, string studentName, long collegeID, long courseID, string studentEmail, long studentMobile)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                if(studentUserName!="" || studentUserName!=null)
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

        public int AddStudent(SqlConnection con, SqlTransaction trans, string studentUserName, string studentName, long collegeID, long courseID, string studentEmail, long studentMobile, string studentAddress, long semID, string studentPassword)
        {
            DataSet MyDataSet = new DataSet();
            SqlCommand cmd = null;
            string qry = "";
            int isUpdated = 0;

            try
            {
                qry = "INSERT INTO tblStudent ";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                //param = new SqlParameter("@AdminName", SqlDbType.VarChar, 50);
                //param.Direction = ParameterDirection.Input;
                //param.Value = adminUserName;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@AdminEmail", SqlDbType.VarChar, 50);
                //param.Direction = ParameterDirection.Input;
                //param.Value = adminEmailID;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@AdminMobile", SqlDbType.BigInt, 50);
                //param.Direction = ParameterDirection.Input;
                //param.Value = adminMobileNo;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@AdminStatus", SqlDbType.Char, 50);
                //param.Direction = ParameterDirection.Input;
                //param.Value = 'A';
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@AdminID", SqlDbType.BigInt, 50);
                //param.Direction = ParameterDirection.Input;
                //param.Value = adminID;
                //cmd.Parameters.Add(param);

                //param = new SqlParameter("@AdminUserName", SqlDbType.VarChar, 50);
                //param.Direction = ParameterDirection.Input;
                //param.Value = adminUserName;
                //cmd.Parameters.Add(param);

                ////MyDataAdapter = new SqlDataAdapter(cmd);
                //isUpdated = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }

            return isUpdated;
        }

        public int EditStudent(SqlConnection con, SqlTransaction trans, string studentUserName, string studentName, long collegeID, long courseID, string studentEmail, long studentMobile, string studentAddress, long semID, string studentPassword)
        {

            return 0;
        }

        public int DeleteStudent(SqlConnection con, SqlTransaction trans, string studentUserName, string CollegeID)
        {
            DataSet MyDataSet = new DataSet();
            SqlCommand cmd = null;
            string qry = "";
            int isStudentDeleted = 0;

            try
            {
                qry = "DELETE FROM tblStudent where StudentUSN=@StudentUserName and CollegeID = @CollegeID";
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

                //MyDataAdapter = new SqlDataAdapter(cmd);
                isStudentDeleted = cmd.ExecuteNonQuery();
            }

            catch (SqlException SqlEx)
            {

            }

            return isStudentDeleted;
        }
    }
}
