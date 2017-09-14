using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SevenSeas.BEANS
{
    public class CruiseBEAN
    {
        public string PortName { get; set; }

        [Display(Name="Cruise Name")]
        public string CruiseName { get; set; }

        [Display(Name = "CruiseID")]
        public int CruiseID { get; set; }
    }
}