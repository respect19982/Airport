using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}