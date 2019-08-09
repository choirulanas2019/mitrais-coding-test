using System;
using System.ComponentModel.DataAnnotations;

namespace MitraisCodingTest.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Mobile number is required")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string Lastname { get; set; }

        [Display(Name = "Date of Birth")]
        public string Month { get; set; }

        public string Date { get; set; }

        public string Year { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        public bool IsRegistrationSucceed { get; set; }
    }
}