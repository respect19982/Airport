using Airport_IS.Models;
using Airport_IS.Models.Entities;
using Airport_IS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Airport_IS.Controllers
{
    public class TicketsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Purchase()
        {
            SelectList flights = new SelectList(db.Flights.Where(p=>p.SourceAirport.AirportName == "Kiev airport"), "FlightName", "FlightName");
            List<Departure> departures = db.Departures.ToList();
       
            List<string> dates = new List<string>();
            foreach (Departure d in departures)
            {
                if (!dates.Contains(d.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))))
                {
                    dates.Add(d.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
                }
            }
            List<string> clss = new List<string>();
            clss.Add("First class");
            clss.Add("Business class");
            clss.Add("Economy class");
            ViewBag.Flights = flights;
            ViewBag.Dates = new SelectList(dates);
            ViewBag.Class = new SelectList(clss);
            return View();
        }

        [HttpPost]
        public ActionResult Purchase(ViewPurchase model, String FlightName, String Date)
        {
            SelectList flights = new SelectList(db.Flights.Where(p => p.SourceAirport.AirportName == "Kiev airport"), "FlightName", "FlightName");
            List<Departure> departures = db.Departures.ToList();
            List<string> dates = new List<string>();
            foreach (Departure p in departures)
            {
                if (!dates.Contains(p.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))))
                {
                    dates.Add(p.DepartureDate.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
                }
            }
            List<string> clss = new List<string>();
            clss.Add("First class");
            clss.Add("Business class");
            clss.Add("Economy class");
            ViewBag.Flights = flights;
            ViewBag.Dates = new SelectList(dates);
            ViewBag.Class = new SelectList(clss);
            DateTime dateTime;
            if (Date != null)
            {
                DateTime.TryParse(Date, out dateTime);
            }
            else
            {
                dateTime = DateTime.Now;
            }

            if (ModelState.IsValid)
            {
                TicketSale ticket = new TicketSale();
                ticket.FirstName = model.FirstName;
                ticket.LastName = model.LastName;
                ticket.PassportSeries = model.PassportSeries;
                ticket.PassportNum = model.PassportNum;
                ticket.Age = model.Age;
                ticket.PhoneNum = model.PhoneNum;
                ticket.Email = model.Email;
                ticket.Class = model.Class;
                ticket.Registered = false;

                var dp = db.Departures.Include(p => p.Flight).Include(p => p.Crew).Include(p => p.Aircraft).Include(p => p.AirportTax).Include(p => p.Rate);


                if (dp.SingleOrDefault(p => p.Flight.FlightName == FlightName && p.DepartureDate == dateTime) == null)
                {
                    ModelState.AddModelError("", "There are no flights on this date");
                    return View("FlightError");


                }
                ticket.DepartureId = dp.Single(p => p.Flight.FlightName == FlightName && p.DepartureDate == dateTime).Id;
                ticket.Departure = dp.Single(p => p.Flight.FlightName == FlightName && p.DepartureDate == dateTime);
                
                
                double classCoff;
                if (ticket.Class == "Economy class") classCoff = 1;
                else if (ticket.Class == "Business class") classCoff = 3;
                else classCoff = 6;
                

                AirportTax airportTax = db.AirportTaxes.Single(p => p.AirportTaxName == ticket.Departure.AirportTax.AirportTaxName);
                Rate rate = db.Rates.Single(p => p.RateName == ticket.Departure.Rate.RateName);
                ticket.TicketPrice = (airportTax.amountOfMoney + rate.amountOfMoney) * classCoff;
                Departure d = db.Departures.Find(ticket.DepartureId);
                d.NumOfPurchasedTickets++;
                db.TicketSales.Add(ticket);
                db.Entry(d).State = EntityState.Modified;
                db.SaveChanges();
                int id = db.TicketSales.Max(p => p.Id);
                TicketSale ticketSale = db.TicketSales.Find(id);
                return View("Res", ticketSale);
            }
            return View(model);
        }
    }
}