//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SevenSeas
{
    using System;
    using System.Collections.Generic;
    
    public partial class adbAttraction
    {
        public adbAttraction()
        {
            this.adbAttractionBooking = new HashSet<adbAttractionBooking>();
        }
    
        public int AttractionID { get; set; }
        public int ExcursionID { get; set; }
        public string Name { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
    
        public virtual ICollection<adbAttractionBooking> adbAttractionBooking { get; set; }
        public virtual adbExcursion adbExcursion { get; set; }
    }
}