using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SevenSeas.BEANS
{
    public class TrackingBEAN
    {
        [Key]
        public int TrackingID { get; set; }

        public string PassengerName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy HH:mm}")]
        public System.DateTime TimeBoard { get; set; }

        public string BoardPort { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy HH:mm}")]
        public Nullable<System.DateTime> TimeAlight { get; set; }

        public string AlightPort { get; set; }

    }
}