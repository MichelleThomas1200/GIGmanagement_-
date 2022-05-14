using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GIG.DAL;
using GIG.Entity;

namespace GIG.BL
{
    public class UserBl
    {
        //UserDAL userDAL = new UserDAL();
        public UserBl()
        {
            //userDAL = new UserDAL();
        }
        
        /*
        SqlConnection conn = new SqlConnection(@"Data source=LAPTOP-4801LI3A; database=gmsDB; Integrated Security=True");
        */

        //1 reference
        public bool AddUser(Users userobj, int uType)
        {
            //string query = "";
            bool b = true;
            UserDAL userDAL = new UserDAL();
            if (uType == 1)
            {
                b=userDAL.Addartist(userobj);
            }
            else
            {
                b=userDAL.Addgiggoer(userobj);
            }
            return b;
        }


        public int CheckUser(Users userobj, int uType)
        {
            int match, success=0;
            UserDAL userDAL = new UserDAL();
            if (uType == 1)
            {
                match = userDAL.Checkartist(userobj);
            }
            else
            {
                match = userDAL.Checkgiggoer(userobj);
            }
            if (match == 0)
                Console.WriteLine("Error: UserName or Password is Incorrect!");
            else
            {
                Console.WriteLine("Log In Successful!");
                String name = userDAL.RetrieveName(userobj, uType);
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Welcome " + name+ " to the Gig Management System");
                Console.WriteLine("----------------------------------");
                success = 1;
            }
            return success;
        }
    }
}
