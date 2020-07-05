using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class Baggage
    {
        public int Id { get; set; }
        [Required]
        public int TicketSaleId { get; set; }
        public TicketSale TicketSale { get; set; }
        [Required]
        public double Weight { get; set; }

    }
}