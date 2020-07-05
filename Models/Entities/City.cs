using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string NameCity { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Airport> Airports { get; set; }
        public City()
        {
            Airports = new List<Airport>();
        }
    }
}