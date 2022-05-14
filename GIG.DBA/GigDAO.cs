using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GIG.Entity;
using GIG.Exceptions;
using System.Configuration;


namespace GIG.DAL
{
    public class GigDAO
    {
        SqlConnection con = null;
        SqlCommand    cmd = null;
        SqlDataReader sdr = null;
        public GigDAO()
        {
            //LAPTOP-4801LI3A
            con = new SqlConnection(@"data source=LAPTOP-4801LI3A; database=GigMangementSystem; Integrated Security=true");
            //con = new SqlConnection();
            //con.ConnectionString = "server=LAPTOP-4801LI3A\\SQLEXPRESS;Integrated Security=true;database=GIG_MANAGEMENT";
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["myconstr"].ConnectionString;
        }
        public bool AddGig1(Gig gigObj) //works
        {
            bool flag = false;
            try
            {
                if(gigObj!=null)
                {
                    con.Open();
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@gigID", gigObj.GIG_ID);
                    param[1] = new SqlParameter("@dateTime", gigObj.DATETIME);
                    param[2] = new SqlParameter("@venue", gigObj.VENUE);
                    param[3] = new SqlParameter("@artist", gigObj.ARTIST);
                    param[4] = new SqlParameter("@genre", gigObj.GENRE);
                    param[5] = new SqlParameter("@isCancelled", gigObj.ISCANCELLED);

                    cmd = new SqlCommand();
                    cmd.CommandText = "Insert into Gig(GIG_ID,DATETIME,VENUE,ARTIST,GENRE,ISCANCELLED)values(@gigID,@dateTime,@venue,@artist,@genre,@isCancelled) ";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddRange(param);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }

                }
            }

            catch (SqlException se)
            {
                throw se;
            }
            catch (CustomException e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }
        public bool UpdateGig(Gig gigObj)
        {
            bool GigUpdated = false;
            try
            {
                if (gigObj != null)
                {
                    con.Open();
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@gigID", gigObj.GIG_ID);
                    param[1] = new SqlParameter("@dateTime", gigObj.DATETIME);
                    param[2] = new SqlParameter("@venue", gigObj.VENUE);
                    param[3] = new SqlParameter("@artist", gigObj.ARTIST);
                    param[4] = new SqlParameter("@genre", gigObj.GENRE);
                    param[5] = new SqlParameter("@isCancelled", gigObj.ISCANCELLED);

                    cmd = new SqlCommand();
                    cmd.CommandText = "Update Gig set (DATETIME=@dateTime,VENUE=@venue,ARTIST=@artist,GENRE=@genre,ISCANCELLED=@isCancelled) where GIG_ID= @gigID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddRange(param);

                    int affectedRows = cmd.ExecuteNonQuery();
                    con.Close();
                    if (affectedRows > 0)
                    {
                        GigUpdated = true;
                    }

                }
                
            /*
            //cmd = new SqlCommand("UpdateGig", con);//?
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param_Id = new SqlParameter("@gigId", SqlDbType.VarChar, 100);
            SqlParameter param_DateTime = new SqlParameter("@dateTime", SqlDbType.DateTime);
            SqlParameter param_Venue = new SqlParameter("@venue", SqlDbType.VarChar, 100);
            SqlParameter param_Artist = new SqlParameter("@artist", SqlDbType.Char, 100);
            SqlParameter param_Genre = new SqlParameter("@genre", SqlDbType.VarChar, 100);
            SqlParameter param_IsCanceled = new SqlParameter("@isCancelled", SqlDbType.VarChar, 1);

            param_Id.Direction = ParameterDirection.Input;
            param_DateTime.Direction = ParameterDirection.Input;
            param_Venue.Direction = ParameterDirection.Input;
            param_Artist.Direction = ParameterDirection.Input;
            param_Genre.Direction = ParameterDirection.Input;
            param_IsCanceled.Direction = ParameterDirection.Input;

            param_Id.Value = gigObj.GIG_ID;
            param_DateTime.Value = gigObj.DATETIME;
            param_Venue.Value = gigObj.VENUE;
            param_Artist.Value = gigObj.ARTIST;
            param_Genre.Value = gigObj.GENRE;
            param_IsCanceled.Value = gigObj.ISCANCELLED;

            cmd.Parameters.Add(param_Id);
            cmd.Parameters.Add(param_DateTime);
            cmd.Parameters.Add(param_Venue);
            cmd.Parameters.Add(param_Artist);
            cmd.Parameters.Add(param_Genre);
            cmd.Parameters.Add(param_IsCanceled);

            //con.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            con.Close();
            if (affectedRows > 0)
            {
                GigUpdated = true;
            }
            */
            }
            catch (CustomException e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return GigUpdated;
        }
        public void DeleteGigDao(Gig gigObj)
        {         
            try
            {            
                cmd = new SqlCommand("DeleteGig", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param_Id = new SqlParameter("@gigId", SqlDbType.VarChar, 20);
                param_Id.Direction = ParameterDirection.Input;                
                param_Id.Value = gigObj.GIG_ID;                
                cmd.Parameters.Add(param_Id);                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();           
            }
            catch (CustomException e)
            {
                throw e;
            }            
        }
        public Gig SearchGigByID(int gigId)
        {
            Gig tempGig = null;
            try
            {
                SqlParameter p1 = new SqlParameter("@gigID", gigId);

                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Gig where GIG_ID=@gigId";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;

                cmd.Parameters.Add(p1);

                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                if (sdr.HasRows)
                {
                    dt.Load(sdr);
                }

                if (dt.Rows.Count > 0)
                {
                    DataRow drow = dt.Rows[0];//Fetch Row from Data Table
                                              //Assign Row Data to Student Object
                    tempGig = new Gig();
                    tempGig.GIG_ID = Int32.Parse(drow[0].ToString());
                    tempGig.DATETIME = DateTime.Parse(drow[1].ToString());
                    tempGig.VENUE = drow[2].ToString();
                    tempGig.ARTIST = drow[3].ToString();
                 
                    tempGig.GENRE = drow[4].ToString();
                   // tempGig.ISCANCELLED = Convert.ToBoolean(drow[4].ToString());

                };
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return tempGig;
        }
        //public bool UpdateGig(int GIG_ID, Gig gigObj)
        //{
        //    bool flag = true;
        //    int result = 0;

        //    try
        //    {
        //        if (gigObj != null)
        //        {

        //            con.Open();

        //            //Init Parameters

        //            SqlParameter[] param = new SqlParameter[6];
        //            param[0] = new SqlParameter("@gigID", gigObj.GIG_ID);
        //            param[1] = new SqlParameter("@dateTime", gigObj.DATETIME);
        //            param[2] = new SqlParameter("@venue", gigObj.VENUE);
        //            param[3] = new SqlParameter("@artist", gigObj.ARTIST);
        //            param[4] = new SqlParameter("@genre", gigObj.GENRE);
        //            param[5] = new SqlParameter("@isCancelled", gigObj.ISCANCELLED);

        //            cmd = new SqlCommand();
        //            cmd.CommandText = "Update Gig set  DATETIME=@dateTime,VENUE=@venue,artist=@artist,GENRE=@genre where GIG_ID=@gigID";
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;

        //            cmd.Parameters.AddRange(param);

        //            result = cmd.ExecuteNonQuery();
        //            if (result > 0)
        //            {
        //                flag = true;
        //            }
        //        }
        //        else
        //        {
        //            flag = false;
        //            throw new CustomException("Gigs is not Updated...");
        //        }
        //    }
        //    catch (CustomException se)
        //    {
        //        throw se;
        //    }
        //    catch (SqlException e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return flag;
        //}        
        public List<Gig> ShowAllGig()
        {
            List<Gig> mygigList = null;
            Gig tempGig = null;
            try
            {
                con.Open();
                             
                
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Gig";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                         
                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                if (sdr.HasRows)
                {
                    dt.Load(sdr);
                }
                //Console.WriteLine(sdr.GetName(0) + "\t\t" + sdr.GetName(1) + "\t" + sdr.GetName(2) + "\t" + sdr.GetName(3) + "\t" + sdr.GetName(4) + "\t" + sdr.GetName(5));
                //Console.WriteLine("------------------------------------------------------------------------------------------------------")
                //if (sdr.Read())
                //{
                //    Console.WriteLine(sdr[0].ToString() + "\t\t" + sdr[1].ToString() + "\t" + sdr[2].ToString() + "\t" + sdr[3].ToString() + "\t" + sdr[4].ToString() + "\t" + sdr[5].ToString());
                //}

                if (dt.Rows.Count > 0)
                {
                    mygigList = new List<Gig>();
                    foreach (DataRow drow in dt.Rows)
                    {
                    //    DataRow drow = dt.Rows[0];//Fetch Row from Data Table
                    //                              //Assign Row Data to Student Object
                        tempGig = new Gig();
                        tempGig.GIG_ID = Int32.Parse(drow[0].ToString());
                        tempGig.DATETIME = DateTime.Parse(drow[1].ToString());
                        tempGig.VENUE = drow[2].ToString();
                        tempGig.ARTIST = drow[3].ToString();
                     
                        tempGig.GENRE = drow[4].ToString();
                       // tempGig.ISCANCELLED = Convert.ToBoolean(drow[4].ToString());

                    mygigList.Add(tempGig);

                    }

                }
                else
                {
                    throw new CustomException($"No Gig Data Found");
                }
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return mygigList;

        }

    }           
}

