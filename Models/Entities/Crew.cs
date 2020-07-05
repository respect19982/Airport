using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class Crew
    {
        public int Id { get; set; }
        [Required]
        public string CrewName { get; set; }
        [Required]
        public int NumberPilotsInCrew { get; set; }
        public int CrewExperience { get; set; }
        public ICollection<Pilot> Pilots { get; set; }
        public ICollection<Departure> Departures { get; set; }
        public Crew()
        {
            Pilots = new List<Pilot>();
            Departures = new List<Departure>();
        }

    }
}