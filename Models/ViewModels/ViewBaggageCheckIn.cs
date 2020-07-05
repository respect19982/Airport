using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.ViewModels
{
    public class ViewBaggageCheckIn
    {
        [Required]
        public int TicketNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PassportSeries { get; set; }
        [Required]
        public string PassportNum { get; set; }
        [Required]
        public double  BaggageWeight { get; set; }
    }
}