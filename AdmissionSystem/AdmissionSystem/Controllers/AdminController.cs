using AdmissionSystem.Models;
using AdmissionSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionSystem.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository adminRepository = new AdminRepository();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns the list of added courses</returns>
        public ActionResult Index()
        {
            var CourseList = adminRepository.GetCourses();
            return View(CourseList);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courses"></param>
        /// <returns>returns a page for adding the course</returns>
        [HttpPost]
        public ActionResult Create(Courses courses)
        {
            adminRepository.AddCourse(courses);
            return View("Index");
        }

        /// <summary>
        /// view course update 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a update page for the course</returns>
        public ActionResult Edit(int id)
        {
            var coursesList = adminRepository.GetCourseById(id);
            if (coursesList.Count > 0)
            {
                var course = coursesList[0];
                return View(course);
            }
            return HttpNotFound();
        }

        /// <summary>
        /// updates the course in available courses
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Courses courses)
        {
            adminRepository.UpdateCourse(courses);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return a course delete page</returns>
        public ActionResult Delete(int id)
        {
            var details = adminRepository.GetCourseById(id).FirstOrDefault();
            return View(details);
        }

        /// <summary>
        /// Deletes the course from the course list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            adminRepository.DeleteCourse(id);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns the add admin page</returns>
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        /// <summary>
        /// creates the add admin
        /// </summary>
        /// <param name="registrationstudent"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddAdmin(Registrationstudent registrationstudent)
        {
            try
            {
                bool IsInserted = false;
                if (ModelState.IsValid)
                {

                    IsInserted = adminRepository.AddAdmin(registrationstudent);
                    Console.WriteLine(IsInserted);
                    if (IsInserted)
                    {
                        TempData["SucessMessage"] = "Admin created";
                    }
                    else
                    {
                        TempData["Error Message"] = "Admin not created";
                    }
                }
                return View("AddAdmin");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns all the added admins</returns>
        public ActionResult ViewAllAdmins()
        {
            
            var admins = adminRepository.GetAllAdmins();
            return View(admins);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>retrieves the list of enquiries from the contactus page</returns>
        public ActionResult StudentsEnquiryDetails()
        {
            var admins = adminRepository.StudentEnquiryList();
            return View(admins);
        }

        /// <summary>
        /// admin dashboard view
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}
