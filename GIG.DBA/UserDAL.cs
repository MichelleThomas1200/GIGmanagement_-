using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using GIG.Entity;

namespace GIG.DAL
{
    public class UserDAL
    {
        public SqlConnection conn;
        public UserDAL()
        {
            conn = new SqlConnection(@"Data source=LAPTOP-4801LI3A; database=gmsDB; Integrated Security=True");
        }
                
        SqlCommand cmd = null;
        //SqlDataReader sdr = null;

        public bool Addartist(Users aobj)//insert data to table
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query =
                  "insert into ARTIST values('" + aobj.USERNAME + "','" + aobj.PASSWORD + "','" + aobj.NAME + "')";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your Username needs to be Unique. Try another.\n"/*+ex.Message*/);
                return false;
            }
            conn.Close();
            return true;
        }
        public bool Addgiggoer(Users uobj)//insert data to table
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                string query =
                  "insert into USERS values('" + uobj.USERNAME + "','" + uobj.PASSWORD + "','" + uobj.NAME + "')";

                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your Username needs to be Unique. Try another.\n"/*+ex.Message*/);
                return false ;
            }
            conn.Close();
            return true;
        }
        
        
        public int Checkartist(Users aobj)//check password match
        {
            int match = 0;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "select * from ARTIST where artistname = '" + aobj.USERNAME + "'";
            cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[1].ToString() == aobj.PASSWORD)
                    match = 1;
                else
                    match = 0;
                dr.Close();
            }
            else
            {
                dr.Close();
                Console.WriteLine("No Account available with this username and password \nError");
            }
            return match;
        }
        public int Checkgiggoer(Users uobj)//check password match
        {
            int match = 0;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "select * from USERS where username = '" + uobj.USERNAME + "'";
            cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[1].ToString() == uobj.PASSWORD)
                    match = 1;
                else
                    match = 0;
                dr.Close();
            }
            else
            {
                dr.Close();
                Console.WriteLine("No Account available with this username and password \nError");
            }
            return match;
        }

        public string RetrieveName(Users obj, int ch1)//getting fullname
        {
            string query="", name="";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if(ch1==1)
            {
                query = "select name from ARTIST where artistname = '"+obj.USERNAME+"';" ;
            }
            else if(ch1 ==2)
            {
                query = "select name from USERS where username = '"+obj.USERNAME+"'";
            }

            cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
                name = dr[0].ToString();
            return name;
        }
    }
}
