using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using GIG.Entity;

namespace GIG.DAL
{
    public class ArtistDAL
    {
        public SqlConnection conn;
        public ArtistDAL()
        {
            conn = new SqlConnection(@"Data source=LAPTOP-4801LI3A; database=gmsDB; Integrated Security=True");
        }
        SqlCommand cmd = null;

        public bool AddGigInfo(Users aobj, Gig gobj)//insert data to table
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query =
                  "insert into GIGS values(" + gobj.GIG_ID + "," + gobj.TIMING + ",'" + gobj.VENUE + "','" + aobj.USERNAME + "','" + gobj.GENRE + "','" + gobj.ISCANCELLED + "')";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {   
                Console.WriteLine("Your GIG_ID needs to be Unique. Try another.\n"+ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            conn.Close();
            return true;
        }
        public bool CancelGig(Users obj, Gig gobj)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query =                  
                  "delete from GIG where gigID="+gobj.GIG_ID;
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("This GIG_ID was not found in the Database\n"/*+ex.Message*/);
                return false;
            }
            return true;
        }
    }
}
