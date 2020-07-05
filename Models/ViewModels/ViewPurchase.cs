using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport_IS.Models.ViewModels
{
    public class ViewPurchase
    {
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
        [Required]
        [Phone]
        public string PhoneNum { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public string Class { get; set; }
    }
}