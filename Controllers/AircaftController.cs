using Airport_IS.Models;
using Airport_IS.Models.Entities;
using Airport_IS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport_IS.Controllerssupport
{
    public class AircraftController : Controller
    {
        // GET: Aircaft
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "admin")]
        public ActionResult AircraftList()
        {
            var airCraft = db.Aircrafts;
            return View(airCraft);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(AircraftView model)
        {
            if (ModelState.IsValid)
            {
                Aircraft aircraft = new Aircraft();
                aircraft.AirCraftBrend = model.AirCraftBrend;
                aircraft.NumberOfSeats = model.NumberOfSeats;
                aircraft.Speed = model.Speed;
                aircraft.TailNum = model.TailNum;
                aircraft.Fuel = model.Fuel;
                db.Aircrafts.Add(aircraft);
                db.SaveChanges();
                return RedirectToAction("AircraftList", "Aircraft");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aircraft = db.Aircrafts.Find(id);
            return View(aircraft);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Aircraft model)
        {
            if (ModelState.IsValid)
            {
                Aircraft aircraft = db.Aircrafts.Find(model.Id); ;
                aircraft.AirCraftBrend = model.AirCraftBrend;
                aircraft.NumberOfSeats = model.NumberOfSeats;
                aircraft.Speed = model.Speed;
                aircraft.TailNum = model.TailNum;
                aircraft.Fuel = model.Fuel;
                db.Entry(aircraft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AircraftList", "Aircraft");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var aircraft = db.Aircrafts.Find(id);
            if(aircraft == null)
            {
                return View("Error");
            }
            db.Aircrafts.Remove(aircraft);
            db.SaveChanges();
            return RedirectToAction("AircraftList", "Aircraft");
        }


    }

    
}