using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SevenSeas.BEANS
{
    public class PassengerCruiseBEAN
    {
        public string PortName { get; set; }

        [Display(Name = "Cruise Name")]
        public string CruiseName { get; set; }

        [Display(Name = "CruiseID")]
        public int CruiseID { get; set; }

        [Display(Name = "PassengerID")]
        public int PassengerID { get; set; }

        [Display(Name = "Passenger Name")]
        public string PassengerName { get; set; }


    }
}