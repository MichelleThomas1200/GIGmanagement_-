using System;
using System.Collections.Generic;
using System.Text;
using GIG.DAL;
using GIG.Entity;

namespace GIG.BL
{
    public  class ArtistBl
    {
        ArtistDAL artistDAL = null;
        public ArtistBl()
        {
            
        }
        public bool AddGigInfo(Users obj, Gig gobj)
        {

            artistDAL = new ArtistDAL();
            bool b = true;
            b = artistDAL.AddGigInfo(obj, gobj);
            return b;
        }
        public bool CancelGig(Users obj, Gig gobj)
        {
            artistDAL = new ArtistDAL();
            bool b = true;
            b = artistDAL.CancelGig(obj, gobj);
            return b;
        }
        public bool UpdateGigInfo(Users obj, Gig gobj)
        {
            artistDAL = new ArtistDAL();
            bool b = true;
            b = artistDAL.CancelGig(obj, gobj);
            return b;
        }
    }
}
