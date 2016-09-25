using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCollege_CL
{
    public class Connection
    {


        public SqlConnection con;

        public SqlTransaction trans;

        public SqlConnection CreateConnection()
        {
            string strCon = "";
            strCon = System.Configuration.ConfigurationManager.AppSettings.Get("GoCollegeConnectionString");
            con = new SqlConnection(strCon);
            return con;
        }

        private void OpenConnection()
        {
            CreateConnection();
            con.Open();
        }

        private void CloseConnection()
        {
            if (con.State.Equals(ConnectionState.Open))
            {
                con.Close();
                con.Dispose();
            }
        }

        public void BeginTransaction()
        {
            OpenConnection();
            trans = con.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void CommitTransaction()
        {
            trans.Commit();
            trans.Dispose();
            CloseConnection();
        }

        public void RollbackTransaction()
        {
            try
            {
                trans.Rollback();
            }
            catch (SqlException)
            {

            }
            trans.Dispose();

            CloseConnection();
        }
    }
}
