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
    
    public partial class adbFirstAid
    {
        public int FirstAidID { get; set; }
        public Nullable<int> AidLevel { get; set; }
        public Nullable<System.DateTime> DateAttained { get; set; }
        public int EmployeeID { get; set; }
    
        public virtual adbEmployee adbEmployee { get; set; }
    }
}