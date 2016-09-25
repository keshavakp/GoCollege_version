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
        //Check for Login Details
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

        //Check for Existing Email and Mobile Number

        public DataView ChkForExisting(SqlConnection con, SqlTransaction trans)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblAdmin";
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

        //Update Admin Details
        public int EditAdmin(SqlConnection con, SqlTransaction trans, string adminUN, string adminName, string adminEmail, Int64 adminMobile, string adminPWD)
        {

            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {

                qry = " Update tblAdmin set AdminName=@adminName,AdminEmail=@adminEmail,AdminMobile=@adminMobile,AdminPassword=@Password,AdminStatus=@adminStatus where AdminUserName=@UserName and AdminStatus='R'";
                    

                //qry = "Select * from tblAdmin where AdminUserName=@UserName and AdminPassword=@Password and AdminStatus in('R','A')"
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;

                // parameter for UserName column
                param = new SqlParameter("@UserName", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUN;
                cmd.Parameters.Add(param);

                // parameter for Admin Name column
                param = new SqlParameter("@adminName", SqlDbType.VarChar, 150);
                param.Direction = ParameterDirection.Input;
                param.Value = adminName;
                cmd.Parameters.Add(param);

                // parameter for Admin Email column
                param = new SqlParameter("@adminEmail", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = adminEmail;
                cmd.Parameters.Add(param);


                // parameter for Admin Mobile column
                param = new SqlParameter("@adminMobile", SqlDbType.BigInt,10 );
                param.Direction = ParameterDirection.Input;
                param.Value = adminMobile;
                cmd.Parameters.Add(param);


                // parameter for Admin Status column
                param = new SqlParameter("@adminStatus", SqlDbType.Char,1);
                param.Direction = ParameterDirection.Input;
                param.Value = 'A';
                cmd.Parameters.Add(param);


                // parameter for Password column
                param = new SqlParameter("@Password", SqlDbType.VarChar, 250);
                param.Direction = ParameterDirection.Input;
                param.Value = adminPWD;
                cmd.Parameters.Add(param);


                int retValue = 0;

                retValue = cmd.ExecuteNonQuery();


                //MyDataAdapter = new SqlDataAdapter(cmd);
                //MyDataAdapter.Fill(MyDataSet);

                return retValue;
            }

            catch (SqlException SqlEx)
            {

            }

            return 0;  

           // return MyDataSet.Tables[0].DefaultView;  
 

        }
       

        //Get College Details
        public DataView FetchCollegeDetails(SqlConnection con, SqlTransaction trans, string adminUN)
        {

            DataSet MyDataSet = new DataSet();
            SqlDataAdapter MyDataAdapter;
            SqlCommand cmd = null;
            string qry = "";
            try
            {
                qry = "Select * from tblCollege where CollegeID in(select CollegeID from tblAdmin where AdminUserName=@UserName)";
                cmd = new SqlCommand(qry, con, trans);
                cmd.CommandType = CommandType.Text;
                SqlParameter param;


                // parameter for UserName column
                param = new SqlParameter("@UserName", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = adminUN;
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
