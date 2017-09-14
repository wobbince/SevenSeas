using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SevenSeas.BEANS
{
    public class PassengerBEAN
    {
        [ScaffoldColumn(false)]
        public int PassengerID { get; set; }
        [Display(Name="First Name")]
        [Required]
        public string first_name { get; set; }
        [Display(Name = "Surname")]
        [Required]
        public string last_name { get; set; }
        [Display(Name = "Address Line 1")]
        [Required]
        public string address { get; set; }
        [Display(Name = "Address Line 2")]
        [Required]
        public string city { get; set; }
        [Display(Name = "Address Line 3")]
        [Required]
        public string county { get; set; }
        [Display(Name = "Postcode")]
        [Required]
        public string postcode { get; set; }
        [Display(Name = "Country")]
        [Required]
        public string country { get; set; }
        [Display(Name = "Phone")]
        [Required]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name="Gender")]
        [Required]
        [StringLength(1, ErrorMessage = "Gender must not exceed 1 characted.")]
        [RegularExpression("^[M][F]*$", ErrorMessage="Must be an M or an F")]
        public string gender { get; set; }
        [Display(Name="Date of Birth")]
        [Required]
        public Nullable<System.DateTime> DOB { get; set; }
    }
}