using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using  GoCollege_BL;
using  GoCollege_DL;

namespace GoCollege_BL
{
    public class PasswordBL
    {



        protected string Msg = "";
        static string SecretErrMsg = "";
        public string DefaultPassword()
        {
            int temp;
            string pwd = "";
            for (int j = 0; j < 8; j++)
            {
                temp = AutoSeed();
                pwd = pwd + Convert.ToChar(temp).ToString();
            }
            return pwd;
        }

        public static string SecretNumber()
        {
            int temp;
            string SecretNumber = "";
            try
            {
                for (int j = 0; j < 8; j++)
                {
                    temp = AutoSeed1();
                    SecretNumber = SecretNumber + Convert.ToChar(temp).ToString();
                }

                return SecretNumber;
            }
            catch (NullReferenceException NullEx)
            {
                SecretErrMsg = "System Cannot Process Your Request";
                return SecretNumber;
            }
            catch (Exception Ex)
            {
                 SecretErrMsg = "System Cannot Process Your Request";
                return SecretNumber;
            }
        }

        private int AutoSeed()
        {
            Thread.Sleep(20);
            Random autoRand = new Random();
            return RandomInt(autoRand, RandomInt(autoRand));
        }

        private int RandomInt(Random randObj)
        {
            int lower = 1;
            int upper = 4;
            int rnd = 0;
            rnd = randObj.Next(lower, upper);
            return rnd;
        }

        private int RandomInt(Random randObj, int rnd)
        {
            int lower;
            int upper;
            if (rnd == 1)
            {
                lower = 48;
                upper = 57;
                rnd = randObj.Next(lower, upper);
                return rnd;
            }
            else if (rnd == 2)
            {
                lower = 65;
                upper = 90;
                rnd = randObj.Next(lower, upper);
                return rnd;
            }
            else
            {
                lower = 97;
                upper = 122;
                rnd = randObj.Next(lower, upper);
                return rnd;
            }
        }

        /*
         * Eliminated following confusing characters for Secret Number
         * UPPER CASE - AEGJKOQSTVX
         * lower case - bdegjklnpqstvx
         * # - 01289
         */

        private static int AutoSeed1()
        {
            Thread.Sleep(20);
            Random autoRand = new Random();
            return RandomInt1(autoRand, RandomInt1(autoRand));
        }

        private static int RandomInt1(Random randObj)
        {
            int lower = 1;
            int upper = 20;
            int rnd = 0;
            rnd = randObj.Next(lower, upper);
            return rnd;
        }

        private static int RandomInt1(Random randObj, int rnd)
        {
            int lower;
            int upper;
            switch (rnd)
            {
                case 1:
                    lower = 66;
                    upper = 68;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 2:
                    lower = 70;
                    upper = 70;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 3:
                    lower = 72;
                    upper = 73;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 4:
                    lower = 76;
                    upper = 78;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 5:
                    lower = 80;
                    upper = 80;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 6:
                    lower = 82;
                    upper = 82;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 7:
                    lower = 85;
                    upper = 85;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 8:
                    lower = 87;
                    upper = 87;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 9:
                    lower = 89;
                    upper = 90;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 10:
                    lower = 97;
                    upper = 97;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 11:
                    lower = 99;
                    upper = 99;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 12:
                    lower = 102;
                    upper = 102;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 13:
                    lower = 104;
                    upper = 105;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 14:
                    lower = 109;
                    upper = 109;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 15:
                    lower = 111;
                    upper = 111;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 16:
                    lower = 114;
                    upper = 114;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 17:
                    lower = 117;
                    upper = 117;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 18:
                    lower = 119;
                    upper = 119;
                    rnd = randObj.Next(lower, upper);
                    break;
                case 19:
                    lower = 122;
                    upper = 122;
                    rnd = randObj.Next(lower, upper);
                    break;
                default:
                    lower = 51;
                    upper = 55;
                    rnd = randObj.Next(lower, upper);
                    break;
            }
            return rnd;
        }

        public string GenerateHash(string SourceText)
        {
            UnicodeEncoding Ue = new UnicodeEncoding();
            byte[] ByteSourceText = Ue.GetBytes(SourceText);
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
            return Convert.ToBase64String(ByteHash);
        }

        public string GetMsg()
        {
            return Msg;
        }
    }
}
