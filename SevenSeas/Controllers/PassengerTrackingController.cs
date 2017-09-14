using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SevenSeas.BEANS;
using System.Data.SqlClient;

namespace SevenSeas.Controllers
{
    public class PassengerTrackingController : Controller
    {
        private SevenSeasEntities _context;

        public PassengerTrackingController()
        {
            _context = new SevenSeasEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public ActionResult ListOfPassengers(int id) // id is the cruiseID
        {



            var _Location = _context.adbTracking
                .GroupBy(x => x.CardID)
                .Select(g => g.OrderByDescending(m => m.TimeBoard).FirstOrDefault()).ToList()
                .Where(g => g.adbShipCard.CruiseID == id)
                .Select(x => new TrackingBEAN
                {

                    TrackingID = x.SequenceID,
                    PassengerName = x.adbShipCard.adbPassengerCruise.adbPassenger.first_name + " " + x.adbShipCard.adbPassengerCruise.adbPassenger.last_name,
                    BoardPort = _context.adbPort.Where(c => c.PortID == x.BoardPortID).Select(c => c.PortName).FirstOrDefault(),
                    TimeBoard = x.TimeBoard,
                    AlightPort = _context.adbPort.Where(c => c.PortID == x.AlightPortID).Select(c => c.PortName).FirstOrDefault(),
                    TimeAlight = x.TimeAlight

                });
            


            return View(_Location);
        }

        public ActionResult updateTracking(int cardid, int portid)
        {
            SqlParameter param1 = new SqlParameter("@cardid", cardid.ToString());
            SqlParameter param2 = new SqlParameter("@portid", portid.ToString());
            _context.Database.ExecuteSqlCommand("checkinout @cardid, @portid",
                                          param1, param2);

            return RedirectToAction("ListOfPassengers", new { id = 3 });
        }

        [HttpGet()]
        public ActionResult listCruises1(int id)
        {
            List<CruiseBEAN> myCollection = new List<CruiseBEAN>();

            using (var ctx = new SevenSeasEntities())
            {
                //Execute TVF and filter result
                var courseList = ctx.WhereIsThisCruiseGoing(id).ToList<WhereIsThisCruiseGoing_Result>();

                foreach (WhereIsThisCruiseGoing_Result cs in courseList)
                {
                    myCollection.Add(new CruiseBEAN { PortName = cs.PortName });
                }
            }

            //using (var ctx = new SevenSeasEntities())
            //{
            //    //Execute TVF and filter result
            //    var courseList = ctx.WhereIsThisCruiseGoing(id).ToList<WhereIsThisCruiseGoing_Result>();

            //    foreach (WhereIsThisCruiseGoing_Result cs in courseList)
            //    {
            //        myCollection.Add(new CruiseBEAN { PortName = cs.PortName });
            //    }
            //}


            return View(myCollection);
        }

    }
}