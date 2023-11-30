using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AdmissionSystem.Models;
using AdmissionSystem.Repository;

namespace AdmissionSystem.Controllers
{
    public class StudentRegisterController : Controller
    {
        StudentRepository studentRepository = new StudentRepository();

        public StudentRegisterController()
        { 
            studentRepository = new StudentRepository();
        }

        /// <summary>
        /// <param></param>
        /// </summary>
        /// <returns>Signup page</returns>
        public ActionResult Signup()
        {
            return View();
        }

        ///<summary></summary>
        ///<param name="registrationstudent"></param>
        ///<returns>Register add students</returns>
        [HttpPost]
        public ActionResult Signup(Registrationstudent registrationstudent )
        {
            try
            {
                bool IsInserted = false;
                if (ModelState.IsValid)
                {

                    IsInserted = studentRepository.AddStudent(registrationstudent);
                    Console.WriteLine(IsInserted);
                    if (IsInserted)
                    {
                        TempData["SucessMessage"] = "User created";
                    }
                    else
                    {
                        TempData["Error Message"] = "User not created";
                    }
                }
                return View("Signin");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// <param name=""></param>
        /// </summary>
        /// <returns>Contact us page</returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// saves the student enquiry to the database
        /// </summary>
        /// <param name="studentEnquiry"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact(StudentEnquiry studentEnquiry)
        {
            bool IsInserted = false;
            Console.WriteLine(IsInserted);
            IsInserted = studentRepository.StudentEnquiryDetails(studentEnquiry);
            if (IsInserted)
            {
                TempData["SucessMessage"] = "Details submitted sucessfully";
            }
            else
            {
                TempData["Error Message"] = "Your not submitted";
            }
            return RedirectToAction("Contact");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns>It is AJAX, does not returns anything</returns>
        
        [HttpGet]
        public JsonResult GetCities(string state)
        {
            var city = studentRepository.GetCity(state);
            return Json(city, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Its a AJAX , does not return anything></returns>
        [HttpGet]
        public JsonResult GetStates()
        {
            var states = studentRepository.GetState();
            return Json(states, JsonRequestBehavior.AllowGet);
        }
    }
}


