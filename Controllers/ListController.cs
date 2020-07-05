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
    public class ListController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Schedule(String FlightName, String Date)
        {
            var f = db.Flights.Include(p => p.SourceAirport);
            SelectList flights = new SelectList(f.Where(p => p.SourceAirport.AirportName == "Kiev airport"), "FlightName", "FlightName");

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
           
            return View(db.Departures.Include(p => p.Flight.SourceAirport).Where(p => p.Flight.SourceAirport.AirportName == "Kiev airport").
                Where(p => p.Flight.FlightName == FlightName || FlightName == null || FlightName == "").
                Where(p => p.DepartureDate == dateTime || Date == null || Date == "").ToList());
        }





        [HttpGet]
        public ActionResult PassengerList(int id)
        {
            Departure dp = db.Departures.Find(id);
            var passList = db.TicketSales.Where(p => p.DepartureId == dp.Id && p.Registered == true);
            if(passList == null)
            {
                return View("Error");
            }
            return View("ListPass", passList);
         }
   
           
        
        [HttpGet]
        public ActionResult BaggageList(int id)
        {
            Departure dp = db.Departures.Find(id);
            var baggage = db.Baggages.Include(p=>p.TicketSale.Departure).Where(p => p.TicketSale.DepartureId == dp.Id);
            if (baggage == null)
            {
                return View("Error");
            }
            return View("ListBaggage", baggage) ;
        }
    }
}