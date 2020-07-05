using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport_IS.Models.Entities
{
    public class Pilot
    {
        public int Id { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public int? CrewId { get; set; }
        public Crew Crew { get; set; }
        [Required]
        public string FirstName{ get; set; }
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        [Required]
        public string PhoneNum { get; set; }
    }
}