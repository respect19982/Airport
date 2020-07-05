using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Airport_IS.Models.Entities
{
    public class Airline
    {
        public int Id { get; set; }
        [Required]
        public string AirlineName { get; set; }

        public ICollection<Flight> Flights { get; set; }
        public Airline()
        {
            Flights = new List<Flight>();
        }
    }
}