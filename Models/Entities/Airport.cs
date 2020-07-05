using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        [Required]
        public string AirportName { get; set; }
        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        public ICollection<Flight> Flights;

        public Airport()
        {
            Flights = new List<Flight>();
        }
    }
}