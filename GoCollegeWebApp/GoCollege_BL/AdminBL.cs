﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCollege_BL;
using GoCollege_CL;
using GoCollege_DL;
using System.Data;


namespace GoCollege_BL
{   

    public class AdminBL
    {
          AdminDL objAdmiDL = new AdminDL();

        PasswordBL objPasswordBL = new PasswordBL();
        
        //Variables

        public DataView AdminLogin(string adminUN,string adminPWD)
        {
               DataView dvMsg=null;
               Connection conn = new Connection();
               try
               {
                   conn.BeginTransaction();

                   string encryptedPassword = objPasswordBL.GenerateHash(adminPWD);
                   adminPWD = encryptedPassword;

                   dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                   if (dvMsg.Count.Equals(0))
                   {
                       conn.CommitTransaction();

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


        //Check for Existing Email ID and Mobile Number
        public DataView ChkForExisting()
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.ChkForExisting(conn.con, conn.trans);

                if (dvMsg.Count.Equals(0))
                {
                    conn.CommitTransaction();

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

        //Check for Existing Email ID.Mobile and Phone Number //College Details
        public DataView ChkForExistingCollegeDetails()
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.ChkForExisting(conn.con, conn.trans);

                if (dvMsg.Count.Equals(0))
                {
                    conn.CommitTransaction();

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



        //Update Admin Details
        public int EditAdmin(string adminUN, string adminName, string adminEmail, Int64 adminMobile, string adminPWD)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                string encryptedPassword = objPasswordBL.GenerateHash(adminPWD);
                adminPWD = encryptedPassword;

                int qryResult = 0;

                qryResult = objAdmiDL.EditAdmin(conn.con, conn.trans, adminUN, adminName, adminEmail, adminMobile, adminPWD);

                //dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                if (qryResult== 0)
                {
                    return qryResult;

                }

                conn.CommitTransaction();

                return 1;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
          //  return dvMsg.Table.DefaultView;
            return 0;
        }


        //Fetch Collge Details
        public DataView FetchCollgeDetails(string adminUN)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();

                dvMsg = objAdmiDL.FetchCollegeDetails(conn.con, conn.trans, adminUN);

                if (dvMsg.Count.Equals(0))
                {
                    conn.CommitTransaction();

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



        //Update College Details
        public int UpdateCollegeDetails(string clgCode,string clgName,string clgEmail,Int64 clgPhone,Int64 clgMobile,string clgAddress)
        {
            DataView dvMsg = null;
            Connection conn = new Connection();
            try
            {
                conn.BeginTransaction();
                             

                int qryResult = 0;

                qryResult = objAdmiDL.UpdateCollegeDetails(conn.con, conn.trans, clgCode, clgName, clgEmail, clgPhone, clgMobile, clgAddress);

                //dvMsg = objAdmiDL.FetchAdminDetails(conn.con, conn.trans, adminUN, adminPWD);

                if (qryResult == 0)
                {
                    return qryResult;

                }

                conn.CommitTransaction();

                return 1;

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
            //  return dvMsg.Table.DefaultView;
            return 0;

            return 0;
        }

        //public DataView GetdvMsg()
        //{
        //    return dvMsg;
        //}

        
    }

}
