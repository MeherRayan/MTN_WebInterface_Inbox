using System;
using System.Collections.Generic;

namespace MTN_WebInterface_Inbox.DB
{
    public partial class TInboxMtn
    {
        public int Id { get; set; }
        public string SpId { get; set; }
        public string ServiceId { get; set; }
        public string TimeStamp { get; set; }
        public string Linkid { get; set; }
        public string Correlator { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Shortcode { get; set; }
        public string TimeSpan { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Media { get; set; }
        public string Request { get; set; }
    }
}
