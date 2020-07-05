using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Airport_IS.Models.Entities
{
    public class Aircraft
    {
        public int Id { get; set; }
        [Required]
        public string AirCraftBrend { get; set; }
        public int Speed { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        public string Fuel { get; set; }
        [Required]
        public int TailNum { get; set; }
        public ICollection<Departure> Departures { get; set; }
        public Aircraft()
        {
            Departures = new List<Departure>();
        }
    }
}