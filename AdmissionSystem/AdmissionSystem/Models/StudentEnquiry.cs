using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionSystem.Models
{
    public class StudentEnquiry
    {
        [DisplayName("First name")]
        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name should contain only alphabets.")]
        public string Firstname { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name should contain only alphabets.")]
        
        public string Lastname { get; set; }

        [DisplayName("Email id")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [DisplayName("Phone number")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid phone number. It should be 10 digits starting with 6, 7, 8, or 9.")]
        public long Phonenumber { get; set; }

        [DisplayName("Enter your message")]
        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}