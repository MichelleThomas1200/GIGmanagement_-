using System;
using System.Collections.Generic;
using System.Text;

namespace GIG.Entity
{
   public  class Artist
    {
        public int GIG_ID { get; set; }
        public int DATETIME { get; set; }
        public string ARTIST { get; set; }
        public string VENUE { get; set; }
        public string GENRE { get; set; }
        public bool ISCANCELLED { get; set; }

    }
}
