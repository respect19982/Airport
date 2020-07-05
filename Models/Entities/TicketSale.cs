using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Airport_IS.Models.Entities
{
    public class TicketSale
    {
        public int Id { get; set; }
        [Required]
        public int DepartureId { get; set; }
        public Departure Departure { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PassportSeries { get; set; }
        [Required]
        public string PassportNum { get; set; }
        [Required]
        public string Age { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public int? PlaceNumber { get; set; }
        [Required]
        public double TicketPrice { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public bool Registered { get; set; }

        public ICollection<Baggage> Baggages { get; set; }
        public TicketSale()
        {
            Baggages = new List<Baggage>();
        }

    }
}