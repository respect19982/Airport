using Airport_IS.Models;
using Airport_IS.Models.Entities;
using Airport_IS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport_IS.Controllers
{
    public class RegistrationController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult PassengerCheckIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BaggageCheckIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PassengerCheckIn(ViewPassCheckIn model)
        {
            if (ModelState.IsValid)
            {
               
                if (db.TicketSales.SingleOrDefault(p => p.Id == model.TicketNumber) == null)
                {
                    return View("RegisteredError");
                }
                TicketSale pass = db.TicketSales.Find(model.TicketNumber);

                if (pass.Registered)
                {
                    return View("PassRegistered");
                }

                if (pass.FirstName != model.FirstName || pass.LastName != model.LastName
                    || pass.PassportSeries != model.PassportSeries || pass.PassportNum != model.PassportNum)
                {
                    return View("RegisteredError2");
                }
                else
                {
                    pass.Departure = db.Departures.Single(p => p.Id == pass.DepartureId);
                    pass.Departure.Aircraft = db.Aircrafts.Single(p => p.Id == pass.Departure.AircraftId);
                    pass.Departure.Flight = db.Flights.Single(p => p.Id == pass.Departure.FlightId);
                    Random random = new Random();
                    pass.Registered = true;
                    int place;
                    var tickets = db.TicketSales.Where(p => p.DepartureId == pass.DepartureId);

                    do{
                        place = random.Next(1, pass.Departure.Aircraft.NumberOfSeats);
                    } while (tickets.SingleOrDefault(p => p.PlaceNumber == place) != null);
                    pass.PlaceNumber = place;
                    Departure d = db.Departures.Find(pass.DepartureId);
                    d.NumOfRegisteredPass++;
                    db.Entry(pass).State = EntityState.Modified;
                    db.Entry(d).State = EntityState.Modified;
                    db.SaveChanges();
                    return View("RegistrationSuccessful", pass);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult BaggageCheckIn(ViewBaggageCheckIn model)
        {
            if (ModelState.IsValid)
            {
                if (db.TicketSales.SingleOrDefault(p => p.Id == model.TicketNumber) == null)
                {
                    return View("RegisteredError");
                }
                TicketSale pass = db.TicketSales.Find(model.TicketNumber);
                if (pass.FirstName != model.FirstName || pass.LastName != model.LastName
                    || pass.PassportSeries != model.PassportSeries || pass.PassportNum != model.PassportNum)
                {
                    return View("RegisteredError2");
                }
                
                if (!pass.Registered)
                {
                    return View("PassNotRegistered");
                }

                else
                {
                    Baggage baggage = new Baggage();
                    baggage.TicketSaleId = pass.Id;
                    baggage.Weight = model.BaggageWeight;
                    db.Baggages.Add(baggage);
                    Departure d = db.Departures.Find(pass.DepartureId);
                    d.NumOfCheckedBaggage++;
                    db.Entry(pass).State = EntityState.Modified;
                    db.Entry(d).State = EntityState.Modified;
                    db.SaveChanges();
                    return View("RegistrationBaggageSuccessful", baggage);
                }
            }
            return View();

        }
                
    }
}