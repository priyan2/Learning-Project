using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionSystem.Models
{
    public class Registrationstudent
    {
        public int Id { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [DisplayName("Date of birth")]
        public string DataOfBirth { get; set; }
        [DisplayName("Email id")]
        public string EmailId { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [DisplayName("Phone number")]
        public string Phonenumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }

        //from StudentProfileDetails

        [Display(Name = "HSC Marks")]
        public int HSCMarks { get; set; }

        [Display(Name = "SSLC Marks")]
        public int SSLCMarks { get; set; }

        [Display(Name = "HSC Group")]
        public string HSCGroup { get; set; }

        [Display(Name = "Subject 1 Mark (Mathematics)")]
        public int Subject1Marks { get; set; }

        [Display(Name = "Subject 2 Marks (Physics)")]
        public int Subject2Marks { get; set; }
        //status property newly added 
        public string status { get; set; }

        [Display(Name = "Subject 3 Marks(Chemistry)")]
        public int Subject3Marks { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }
        [Display(Name = "Upload Image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}