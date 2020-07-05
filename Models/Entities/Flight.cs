using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Airport_IS.Models.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public int AirlineId { get; set; }
        [Required]
        public int SourceAirportId { get; set; }
        [Required]
        public int DestinationAirportId { get; set; }
        public Airport SourceAirport { get; set; }
        public Airline Airline { get; set; }
        public Airport DestinationAirport { get; set; }
        [Required]
        public string FlightName { get; set; }
        [Required]
        public TimeSpan DepartureTime { get; set; }
        [Required]
        public TimeSpan ArrivalTime { get; set; }
        [Required]
        public TimeSpan FlightTime { get; set; }
        public string FlightType { get; set; }

        public ICollection<Departure> Departures { get; set; }
        public Flight()
        {
            Departures = new List<Departure>();
        }
    }
}