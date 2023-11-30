using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionSystem.Models
{
    public class Courses
    {
        public int CourseId { get; set; }
        [Display (Name = "Course name ")]
        public string CourseName { get; set; }
        [Display(Name = "Available seats")]
        public int SeatsAvailable { get; set; }
        [Display(Name = "Course description")]
        public string CourseDescription { get; set; }
    }
}