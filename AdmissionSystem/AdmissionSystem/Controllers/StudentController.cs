using AdmissionSystem.Models;
using AdmissionSystem.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository studentRepositoryProfile = new StudentRepository();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminRepository"></param>
        /// <returns>Retrives all the courses from the database</returns>
        public ActionResult ViewCourse(AdminRepository adminRepository)
        {
            var course = adminRepository.GetCourses();
            return View(course);
        }

        /// <summary>
        /// Gets the student profile view page
        /// </summary>
        /// <returns>returns student profile page</returns>
        public ActionResult StudentProfile()
        {
            var Id = Session["Id"];
            return View();
        }

        /// <summary>
        /// posts the student marks details to the database
        /// </summary>
        /// <param name="registrationstudent"></param>
        /// <param name="ImageFile"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentProfile(Registrationstudent registrationstudent, HttpPostedFileBase ImageFile)
        {
            try
            {
                var userId = Session["Id"];
                if (registrationstudent.ImageFile != null)
                {
                    string fileExtension = Path.GetExtension(registrationstudent.ImageFile.FileName).ToLower();
                    if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png")
                    {
                        using (BinaryReader reader = new BinaryReader(registrationstudent.ImageFile.InputStream))
                        {
                            registrationstudent.Image = reader.ReadBytes((int)registrationstudent.ImageFile.InputStream.Length);
                        }
                    var user= Session["Id"];
                    registrationstudent.Id = Convert.ToInt32(userId);
                        studentRepositoryProfile.StudentProfileAdd(registrationstudent);
                        return View("StudentProfileDetails");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Invalid file format. Please upload a JPEG or JPG image.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Please select an image.";
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminRepository"></param>
        /// <returns>returns the course list</returns>
        [HttpGet]
        public ActionResult AvailableCourses(AdminRepository adminRepository) 
        {
            var course = adminRepository.GetCourses();
            return View(course);
        }
        public ActionResult AvailableCourses(int id)
        {
            return View();
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns the profile data</returns>
        
        public ActionResult ViewProfile()
        {
            var userId = Session["Id"];
            List<Registrationstudent> getDetail = studentRepositoryProfile.GetAllDetails(Convert.ToInt32(userId));
            return View(getDetail);
        }

        /// <summary>
        /// Apply to the course
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        public ActionResult ApplyToCourse(Registrationstudent registrationstudent, Courses courses)
        {
            var userId = Session["Id"];
            //studentRepositoryProfile.ApplyCourse();
            return View();
        }
    }
}
