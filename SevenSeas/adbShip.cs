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
    
    public partial class adbShip
    {
        public adbShip()
        {
            this.adbCruise = new HashSet<adbCruise>();
            this.adbMobilePhone = new HashSet<adbMobilePhone>();
        }
    
        public int ShipID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Built { get; set; }
        public Nullable<decimal> Tonnage { get; set; }
        public Nullable<int> Cabins { get; set; }
        public Nullable<int> Passengers { get; set; }
        public Nullable<int> Decks { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<adbCruise> adbCruise { get; set; }
        public virtual ICollection<adbMobilePhone> adbMobilePhone { get; set; }
    }
}