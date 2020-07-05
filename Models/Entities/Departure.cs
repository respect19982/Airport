using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class Departure
    {
        public int Id { get; set; }
        [Required]
        public int CrewId { get; set; }
        public Crew Crew { get; set; }
        [Required]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        [Required]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
        [Required]
        public int RateId { get; set; }
        public Rate Rate { get; set; }
        [Required]
        public int AirportTaxId { get; set; }
        public AirportTax AirportTax { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int NumOfPurchasedTickets { get; set; }
        [Required]
        public int NumOfRegisteredPass { get; set; }
        [Required]
        public int NumOfCheckedBaggage { get; set; }

        public ICollection<TicketSale> TicketSales { get; set; }
        public Departure()
        {
            TicketSales = new List<TicketSale>();
        }

    }
}