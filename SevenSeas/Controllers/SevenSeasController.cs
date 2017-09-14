using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SevenSeas.BEANS;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Validation;

namespace SevenSeas.Controllers
{
    public class SevenSeasController : Controller
    {
        private SevenSeasEntities _context;

        public SevenSeasController()
        {
            _context = new SevenSeasEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: SevenSeas
        public ActionResult listPassengers()
        {
            var _Passengers = _context.adbPassenger.ToList();

            return View(_Passengers);
        }

        [HttpGet()]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(PassengerBEAN _Passenger)
        {
            adbPassenger _newPassenger = new adbPassenger();

            _newPassenger.city = _Passenger.city;
            _newPassenger.country = _Passenger.country;
            _newPassenger.address = _Passenger.address;
            _newPassenger.county = _Passenger.county;
            _newPassenger.DOB = _Passenger.DOB;
            _newPassenger.email = _Passenger.email;
            _newPassenger.first_name = _Passenger.first_name;
            _newPassenger.gender = _Passenger.gender;
            _newPassenger.last_name = _Passenger.last_name;
            _newPassenger.phone = _Passenger.phone;
            _newPassenger.postcode = _Passenger.postcode;


            _context.adbPassenger.Add(_newPassenger);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = _newPassenger.PassengerID, controller = "SevenSeas" });
            }
            catch (DbEntityValidationException exception)
            {

                //var errorMessages = exception.EntityValidationErrors
                //    .SelectMany(x => x.ValidationErrors)
                //    .Select(x => x.ErrorMessage);

                List<string> errorMessages = new List<string>();
                foreach (DbEntityValidationResult validationResult in exception.EntityValidationErrors)
                {
                    string entityName = validationResult.Entry.Entity.GetType().Name;
                    foreach (DbValidationError error in validationResult.ValidationErrors)
                    {
                        this.AddNotification(error.ErrorMessage, NotificationType.ERROR);
                        //errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                    }
                }

                //foreach (var ve in eve.ValidationErrors)
                //{
                //    Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                //        ve.PropertyName,
                //        eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                //        ve.ErrorMessage);
                //}





                return View();
            }
        }

        [HttpGet()]
        public ActionResult Details(int id)
        {
            var _Passenger = _context.adbPassenger.Where(x => x.PassengerID == id).First();

            return View(_Passenger);
        }

        [HttpGet()]
        public ActionResult Edit(int id)
        {
            var _Passenger = _context.adbPassenger.Where(x => x.PassengerID == id).First();

            return View(_Passenger);
        }

        [HttpPost()]
        public ActionResult Edit(adbPassenger _Passenger)
        {
            var _Pass = _context.adbPassenger.Where(x => x.PassengerID == _Passenger.PassengerID).First();

            _Pass.first_name = _Passenger.first_name;
            _Pass.last_name = _Passenger.last_name;
            _Pass.address = _Passenger.address;
            _Pass.city = _Passenger.city;
            _Pass.county = _Passenger.county;
            _Pass.postcode = _Passenger.postcode;
            _Pass.phone = _Passenger.phone;
            _Pass.email = _Passenger.email;
            _Pass.gender = _Passenger.gender;
            _Pass.DOB = _Passenger.DOB;

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = _Passenger.PassengerID, controller = "SevenSeas" });
        }

        [HttpGet()]
        public ActionResult listCruises()
        {
            var listCruises = _context.adbCruise
                                .OrderByDescending(x => x.StartDate)
                                .Where(x => x.ReturnDateTime > System.DateTime.Now);

            return View(listCruises);
        }

        [HttpGet()]
        public ActionResult cruiseDetails(int id)
        {
            var _CruiseSchedule = _context.adbCruiseRouteSchedule.Where(x => x.CruiseID == id);

            var _RouteID = _CruiseSchedule.Select(x => x.RouteID).First();

            ViewBag.RouteName = _context.adbRoute
                                .Where(x => x.RouteID == _RouteID )
                                .Select(c => c.RouteName).First();

            return View(_CruiseSchedule);
        }

        [HttpGet()]
        public ActionResult AddPassengerToCruise(int id)
        {
            PassengerCruiseBEAN _PassengerCruise = new PassengerCruiseBEAN();
            _PassengerCruise.CruiseID = id;
            _PassengerCruise.CruiseName = _context.adbCruise.Where(x => x.CruiseID == id).Select(x => x.Name).First();

            var passengers =  _context.adbPassenger
                                .OrderBy(p => p.first_name).ThenBy(p => p.last_name)
                                //.Where(p => !_context.adbPassengerCruise.Where(pc => pc.PassengerID == p.PassengerID && pc.CruiseID == id).Any())
                                .ToList().Select(u => new SelectListItem
                                {
                                    Text = u.first_name + " " + u.last_name,
                                    Value = u.PassengerID.ToString()
                                });

            ViewBag.Passengers = passengers;

            return View(_PassengerCruise);
        }

        [HttpPost()]
        public ActionResult AddPassengerToCruise(PassengerCruiseBEAN _PassengerCruise)
        {

            //SqlParameter param1 = new SqlParameter("@cruiseid", _PassengerCruise.CruiseID.ToString());
            //SqlParameter param2 = new SqlParameter("@passengerid", _PassengerCruise.PassengerID.ToString());
            //_context.Database.ExecuteSqlCommand("CruiseBooking @cruiseid, @passengerid",
            //                              param1, param2);

            ExecuteStoredProc(_PassengerCruise);

            //return RedirectToAction("ListOfPassengers", new { id = 3 });


            var passengers = _context.adbPassenger
                                .OrderBy(d => d.first_name).ThenBy(d => d.last_name)
                                //.Where(s => !_context.adbPassengerCruise.Where(ps => ps.PassengerID == s.PassengerID).Any())
                                .ToList().Select(u => new SelectListItem
                                {
                                    Text = u.first_name + " " + u.last_name,
                                    Value = u.PassengerID.ToString()
                                });

            ViewBag.Passengers = passengers;

            return RedirectToAction("AddPassengerToCruise", new { id = _PassengerCruise.CruiseID });
        }

        public void ExecuteStoredProc(PassengerCruiseBEAN _PassengerCruise)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("CruiseBooking", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cruiseid", _PassengerCruise.CruiseID);
                command.Parameters.AddWithValue("@passengerid", _PassengerCruise.PassengerID.ToString());

                connection.Open();
                connection.InfoMessage += connection_InfoMessage;
                try
                {
                    var result = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    this.AddNotification(e.Message, NotificationType.INFO);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        void connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            var outputFromStoredProcedure = e.Message;   
        }



    }
}