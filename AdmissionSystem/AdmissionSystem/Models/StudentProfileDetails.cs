using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionSystem.Models
{
    public class StudentProfileDetails
    {
        public int Id { get; set; }
        
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

        [Display(Name = "Subject 3 Marks(Chemistry)")]
        public int Subject3Marks { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }
        [Display(Name ="Upload Image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }

}
