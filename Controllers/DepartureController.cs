using Airport_IS.Models;
using Airport_IS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Airport_IS.Controllers
{
    public class DepartureController : Controller
    {
        // GET: Departure
        ApplicationDbContext db = new ApplicationDbContext();


 
        [HttpGet]
        public ActionResult Schedule(String FlightName, String Date, String Type)
        {
            SelectList flights = new SelectList(db.Flights, "FlightName", "FlightName");
            List<string> types = new List<string>() { "Departures", "Arrivals"};

            List<Departure> departures = db.Departures.ToList();
            List<string> dates = new List<string>();
            DateTime dateTime;
            if (Date != null)
            {
                DateTime.TryParse(Date, out dateTime);
            }
            else
            {
                dateTime = DateTime.Now;
            }
            foreach (Departure d in departures)
            {
                if (!dates.Contains(d.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))))
                {
                    dates.Add(d.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
                }
            }
            Airport c = db.Airports.FirstOrDefault(p => p.AirportName == "Kiev airport");
            
         

            ViewBag.Flights = flights;
            ViewBag.Dates = new SelectList(dates);
            ViewBag.Types = new SelectList(types);

            var dp = db.Departures.Include(p => p.Flight).Include(p => p.Crew).Include(p => p.Aircraft);

            if (Type == "Departures")
            {
                return View(db.Departures.Include(p => p.Flight.Airline).Include(p => p.Crew).Include(p => p.Aircraft).
                 Where(p => p.Flight.FlightName == FlightName || FlightName == null || FlightName == "").
                 Where(p => p.DepartureDate == dateTime || Date == null || Date == "").
                 Where(p => p.Flight.SourceAirport.AirportName == c.AirportName).ToList());
            } else if(Type == "Arrivals")
            {
                return View(db.Departures.Include(p => p.Flight.Airline).Include(p => p.Crew).Include(p => p.Aircraft).
                 Where(p => p.Flight.FlightName == FlightName || FlightName == null || FlightName == "").
                 Where(p => p.DepartureDate == dateTime || Date == null || Date == "").
                 Where(p => p.Flight.DestinationAirport.AirportName == c.AirportName).ToList());
            }
            else
            {
                return View(db.Departures.Include(p => p.Flight.Airline).Include(p => p.Crew).Include(p => p.Aircraft).
                 Where(p => p.Flight.FlightName == FlightName || FlightName == null || FlightName == "").
                 Where(p => p.DepartureDate == dateTime || Date == null || Date == "").ToList());
            }
        }

      
        [HttpPost]
        public ActionResult Schedule(Departure departure)
        {
           
            return RedirectToAction("Schedule", "Departure");
        }



        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult ScheduleForDispatchers(String FlightName, String Date, String Type)
        {
            SelectList flights = new SelectList(db.Flights, "FlightName", "FlightName");
            List<string> types = new List<string>() { "Departures", "Arrivals" };

            List<Departure> departures = db.Departures.ToList();
            List<string> dates = new List<string>();
            DateTime dateTime;
            if (Date != null)
            {
                DateTime.TryParse(Date, out dateTime);
            }
            else
            {
                dateTime = DateTime.Now;
            }
            foreach (Departure d in departures)
            {
                if (!dates.Contains(d.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))))
                {
                    dates.Add(d.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
                }
            }
            Airport c = db.Airports.FirstOrDefault(p => p.AirportName == "Kiev airport");



            ViewBag.Flights = flights;
            ViewBag.Dates = new SelectList(dates);
            ViewBag.Types = new SelectList(types);

            var dp = db.Departures.Include(p => p.Flight).Include(p => p.Crew).Include(p => p.Aircraft).Include(p => p.Flight.Airline).Include(p => p.Flight.DestinationAirport).Include(p => p.Flight.SourceAirport).
                Include(p => p.Crew.Pilots);

            if (Type == "Departures")
            {
                return View(dp.Where(p => p.Flight.FlightName == FlightName || FlightName == null || FlightName == "").
                 Where(p => p.DepartureDate == dateTime || Date == null || Date == "").
                 Where(p => p.Flight.SourceAirport.AirportName == c.AirportName).ToList());
            }
            else if (Type == "Arrivals")
            {
                return View(dp.Where(p => p.Flight.FlightName == FlightName || FlightName == null || FlightName == "").
                 Where(p => p.DepartureDate == dateTime || Date == null || Date == "").
                 Where(p => p.Flight.DestinationAirport.AirportName == c.AirportName).ToList());
            }
            else
            {
                return View(dp.Where(p => p.Flight.FlightName == FlightName || FlightName == null || FlightName == "").
                 Where(p => p.DepartureDate == dateTime || Date == null || Date == "").ToList());
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult ScheduleForDispatchers(Departure departure)
        {

            return RedirectToAction("ScheduleForDispatchers", "Departure");
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Details(int id)
        {
           
            Departure dp = db.Departures.Find(id);
            dp.Flight = db.Flights.FirstOrDefault(p => p.Id == dp.FlightId);
            dp.Flight.SourceAirport = db.Airports.FirstOrDefault(p => p.Id == dp.Flight.SourceAirportId);
            dp.Flight.DestinationAirport = db.Airports.FirstOrDefault(p => p.Id == dp.Flight.DestinationAirportId);
            dp.Flight.SourceAirport.City = db.Cities.FirstOrDefault(p => p.Id == dp.Flight.SourceAirport.CityId);
            dp.Flight.DestinationAirport.City = db.Cities.FirstOrDefault(p => p.Id == dp.Flight.DestinationAirport.CityId);
            dp.Flight.SourceAirport.City.Country = db.Countries.FirstOrDefault(p => p.Id == dp.Flight.SourceAirport.City.CountryId);
            dp.Flight.DestinationAirport.City.Country = db.Countries.FirstOrDefault(p => p.Id == dp.Flight.DestinationAirport.City.CountryId);
            dp.Flight.Airline = db.Airlines.FirstOrDefault(p => p.Id == dp.Flight.AirlineId);
            dp.AirportTax = db.AirportTaxes.FirstOrDefault(p => p.Id == dp.AirportTaxId);
            dp.Rate = db.Rates.FirstOrDefault(p => p.Id == dp.RateId);
            dp.Aircraft = db.Aircrafts.FirstOrDefault(p => p.Id == dp.AircraftId);
            dp.Crew = db.Crews.FirstOrDefault(p => p.Id == dp.CrewId);
            dp.Crew.Pilots = db.Pilots.Where(p => p.CrewId == dp.CrewId).ToList();
            foreach(Pilot pilot in dp.Crew.Pilots)
            {
                pilot.Position = db.Positions.FirstOrDefault(p => p.Id == pilot.PositionId);
            }
            return View(dp);
        }


    }
}