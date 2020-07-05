using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        [Required]
        public string RateName { get; set; }
        [Required]
        public int amountOfMoney { get; set; }

        public ICollection<Departure> Departures  { get; set; }
        public Rate()
        {
            Departures = new List<Departure>();
        }
    }
}