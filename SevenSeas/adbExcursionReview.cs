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
    
    public partial class adbExcursionReview
    {
        public int PassengerID { get; set; }
        public int ExcursionID { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public Nullable<int> Score { get; set; }
    
        public virtual adbExcursion adbExcursion { get; set; }
        public virtual adbPassenger adbPassenger { get; set; }
    }
}
