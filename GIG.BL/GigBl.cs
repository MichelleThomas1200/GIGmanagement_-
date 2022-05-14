using GIG.DAL;
using GIG.Entity;
using GIG.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GIG.BL
{
    public class GigBl
    {
        GigDAO gigdao = null;
        public GigBl()
        {
            gigdao = new GigDAO();
        }
        public bool AddGig(Gig gigObj)
        {
            return gigdao.AddGig1(gigObj);
        }
        private static bool ValidateGig(Gig gigObj)
        {
            StringBuilder sb = new StringBuilder();

            bool validGig = true;
            if (gigObj.GIG_ID <= 0)
            {
                validGig = false;
                sb.Append(Environment.NewLine + "Invalid GIG_ID");
            }
            if (gigObj.ARTIST == string.Empty)
            {
                validGig = false;
                sb.Append(Environment.NewLine + "ArtistName Required");
            }
            if (gigObj.VENUE == string.Empty)
            {
                validGig = false;
                sb.Append(Environment.NewLine + "Required Venue");
            }
            if (validGig == false)
                throw new CustomException(sb.ToString());
            return validGig;
        }
        public bool UpdateGig(Gig gigObj)
        {
            bool GigUpdated = false;
            try
            {
                if (ValidateGig(gigObj))
                {
                    gigdao = new GigDAO();
                    GigUpdated = gigdao.UpdateGig(gigObj);
                }
            }
            catch (CustomException e)
            {

                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GigUpdated;
        }
        public static void DeleteGigBl(Gig gigObj)
        {
            try
            {
                GigDAO gigdao = new GigDAO();
                gigdao.DeleteGigDao(gigObj);
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public Gig SearchGigByID(int gigId)
        {
            return gigdao.SearchGigByID(gigId);

        }
        public List<Gig> ShowAllGig()
        {
            return gigdao.ShowAllGig();
        }
    }  
}
