using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.ViewModels
{
    public class AircraftView
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AirCraftBrend { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        public string Fuel { get; set; }
        [Required]
        public int TailNum { get; set; }

    }
}