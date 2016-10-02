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


        //Add new Faculty Details  and / or check for duplicatte

        public int AddNew_FetchDuplicate(long collegeID, long facultyID, string facultyPassword, string facultyStatus)
        {

        }

        
    }
}
