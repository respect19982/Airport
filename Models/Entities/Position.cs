using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.Entities
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        public string PositionName { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public double Prize { get; set; }

        public ICollection<Pilot> Pilots { get; set; }

        public int Property
        {
            get => default;
            set
            {
            }
        }

        public Position()
        {
            Pilots = new List<Pilot>();
        }
    }
}