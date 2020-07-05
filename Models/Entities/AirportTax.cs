using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class AirportTax
    {
        public int Id { get; set; }
        [Required]
        public string AirportTaxName { get; set; }
        [Required]
        public int amountOfMoney { get; set; }

        public ICollection<Departure> Departures { get; set; }
        public AirportTax()
        {
            Departures = new List<Departure>();
        }

    }
}