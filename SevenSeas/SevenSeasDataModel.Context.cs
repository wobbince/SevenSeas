﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class SevenSeasEntities : DbContext
    {
        public SevenSeasEntities()
            : base("name=SevenSeasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<adbAttraction> adbAttraction { get; set; }
        public DbSet<adbAttractionBooking> adbAttractionBooking { get; set; }
        public DbSet<adbBusCard> adbBusCard { get; set; }
        public DbSet<adbBusEscort> adbBusEscort { get; set; }
        public DbSet<adbBusJourney> adbBusJourney { get; set; }
        public DbSet<adbCrew> adbCrew { get; set; }
        public DbSet<adbCruise> adbCruise { get; set; }
        public DbSet<adbCruiseRouteSchedule> adbCruiseRouteSchedule { get; set; }
        public DbSet<adbEmployee> adbEmployee { get; set; }
        public DbSet<adbExcursion> adbExcursion { get; set; }
        public DbSet<adbExcursionBooking> adbExcursionBooking { get; set; }
        public DbSet<adbExcursionReview> adbExcursionReview { get; set; }
        public DbSet<adbFirstAid> adbFirstAid { get; set; }
        public DbSet<adbGuestLecturer> adbGuestLecturer { get; set; }
        public DbSet<adbGuestLecturerGuest> adbGuestLecturerGuest { get; set; }
        public DbSet<adbMobilePhone> adbMobilePhone { get; set; }
        public DbSet<adbPassenger> adbPassenger { get; set; }
        public DbSet<adbPassengerCruise> adbPassengerCruise { get; set; }
        public DbSet<adbPort> adbPort { get; set; }
        public DbSet<adbRoute> adbRoute { get; set; }
        public DbSet<adbShip> adbShip { get; set; }
        public DbSet<adbShipCard> adbShipCard { get; set; }
        public DbSet<adbTracking> adbTracking { get; set; }
    
        public virtual int CheckInOut(Nullable<int> cardID, Nullable<int> portID)
        {
            var cardIDParameter = cardID.HasValue ?
                new ObjectParameter("CardID", cardID) :
                new ObjectParameter("CardID", typeof(int));
    
            var portIDParameter = portID.HasValue ?
                new ObjectParameter("PortID", portID) :
                new ObjectParameter("PortID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckInOut", cardIDParameter, portIDParameter);
        }
    
        public virtual ObjectResult<PassengersOnBus_Result> PassengersOnBus(Nullable<int> busJourney)
        {
            var busJourneyParameter = busJourney.HasValue ?
                new ObjectParameter("BusJourney", busJourney) :
                new ObjectParameter("BusJourney", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PassengersOnBus_Result>("PassengersOnBus", busJourneyParameter);
        }
    
        public virtual int TrackPassenger(Nullable<int> passengerid)
        {
            var passengeridParameter = passengerid.HasValue ?
                new ObjectParameter("passengerid", passengerid) :
                new ObjectParameter("passengerid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TrackPassenger", passengeridParameter);
        }
    
        public virtual ObjectResult<WhereIsThisCruiseGoing_Result> WhereIsThisCruiseGoing(Nullable<int> cruise)
        {
            var cruiseParameter = cruise.HasValue ?
                new ObjectParameter("Cruise", cruise) :
                new ObjectParameter("Cruise", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WhereIsThisCruiseGoing_Result>("WhereIsThisCruiseGoing", cruiseParameter);
        }
    
        public virtual ObjectResult<ex_2_Result> ex_2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ex_2_Result>("ex_2");
        }
    
        public virtual ObjectResult<ex_3_Result> ex_3(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ex_3_Result>("ex_3", iDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> ex_3_1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ex_3_1");
        }
    
        public virtual int CruiseBooking(Nullable<int> cruiseid, Nullable<int> passengerid)
        {
            var cruiseidParameter = cruiseid.HasValue ?
                new ObjectParameter("cruiseid", cruiseid) :
                new ObjectParameter("cruiseid", typeof(int));
    
            var passengeridParameter = passengerid.HasValue ?
                new ObjectParameter("passengerid", passengerid) :
                new ObjectParameter("passengerid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CruiseBooking", cruiseidParameter, passengeridParameter);
        }
    
        public virtual ObjectResult<NotEscorts_Result> NotEscorts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NotEscorts_Result>("NotEscorts");
        }
    
        public virtual ObjectResult<ValidEscorts_Result> ValidEscorts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ValidEscorts_Result>("ValidEscorts");
        }
    
        public virtual ObjectResult<CheckifonBoard_Result> CheckifonBoard(Nullable<int> cruise)
        {
            var cruiseParameter = cruise.HasValue ?
                new ObjectParameter("cruise", cruise) :
                new ObjectParameter("cruise", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CheckifonBoard_Result>("CheckifonBoard", cruiseParameter);
        }
    }
}
