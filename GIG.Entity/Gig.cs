using System;
using System.Collections.Generic;
using System.Text;

namespace GIG.Entity
{
   public class Gig
    {
        public int GIG_ID { get; set; }
        public DateTime TIMING { get; set; }
        public string ARTIST { get; set; }
        public string VENUE { get; set; }
        public string GENRE { get; set; }
        public string ISCANCELLED { get; set; }
    }
}
