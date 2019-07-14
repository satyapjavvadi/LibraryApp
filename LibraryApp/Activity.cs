using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    enum ActivityType
    {
        Checkout,
        Checkin
    }
    class Activity
    {        
        public int ActivityId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Description { get; set; }
        public int BookCount { get; set; }
        public ActivityType ActivityType { get; set; }
        public int AccountNumber { get; set; }
        public virtual Account Account  { get; set; }
    }
}
