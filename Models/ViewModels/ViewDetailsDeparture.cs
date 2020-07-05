using Airport_IS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.ViewModels
{
    public class ViewDetailsDeparture
    {
       
        public Flight Flight { get; set; }
        public Flight Crew { get; set; }
        public Flight AirportTax { get; set; }
        public Flight AirportRate { get; set; }
    }
}