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
    
    public partial class adbRoute
    {
        public adbRoute()
        {
            this.adbCruise = new HashSet<adbCruise>();
            this.adbCruiseRouteSchedule = new HashSet<adbCruiseRouteSchedule>();
        }
    
        public int RouteID { get; set; }
        public string RouteName { get; set; }
        public int RouteFrom { get; set; }
        public int RouteTo { get; set; }
        public int Duration { get; set; }
    
        public virtual ICollection<adbCruise> adbCruise { get; set; }
        public virtual ICollection<adbCruiseRouteSchedule> adbCruiseRouteSchedule { get; set; }
        public virtual adbPort adbPort { get; set; }
        public virtual adbPort adbPort1 { get; set; }
    }
}
