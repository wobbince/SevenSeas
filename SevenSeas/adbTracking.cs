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
    
    public partial class adbTracking
    {
        public int SequenceID { get; set; }
        public int CardID { get; set; }
        public int BoardPortID { get; set; }
        public System.DateTime TimeBoard { get; set; }
        public Nullable<System.DateTime> TimeAlight { get; set; }
        public Nullable<int> AlightPortID { get; set; }
    
        public virtual adbPort adbPort { get; set; }
        public virtual adbPort adbPort1 { get; set; }
        public virtual adbShipCard adbShipCard { get; set; }
    }
}
