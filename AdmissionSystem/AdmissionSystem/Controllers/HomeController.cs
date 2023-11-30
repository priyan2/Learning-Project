using AdmissionSystem.Models;
using AdmissionSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionSystem.Controllers
{
    public class HomeController : Controller
    {
        LoginRepository loginRepository = new LoginRepository();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns the Main Index</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns the aboutus page </returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns the contact us page</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns to the offered course list page</returns>
        public ActionResult Courses()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>return the sigin page</returns>
        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        /// <summary>
        /// Authenticates the user based on the role
        /// </summary>
        /// <param name="signinModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Signin(SigninModel signinModel)
        {
            if (ModelState.IsValid)
            {
                Registrationstudent user = loginRepository.GetUser(signinModel.Username, signinModel.Password);
                var person = signinModel.Username;
                if ( user != null)
                {
                    
                    Session["Id"] = user.Id;
                    Session["Username"] = user.Username;
                    Session["UserDetails"] = user;
                    Session["Password"] = user.Password;
                    Session["Sslscmarks"] = user.SSLCMarks;
                    Session["Subject1mark"] = user.Subject1Marks;
                    Session["Subject2mark"] = user.Subject2Marks;
                    Session["Subject3mark"] = user.Subject3Marks;
                    Session["Image"] = user.Image;

                    if (user.Role == "admin")
                    {
                        string username = signinModel.Username;
                        Session["Username"] = username;
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (user.Role == "user")
                    {
                        string username = signinModel.Username;
                        
                        Session["Username"] = username;
                        
                        return RedirectToAction("ViewCourse", "Student");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            return View(signinModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Logs from the session</returns>
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns to the change password page</returns>
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// changes the password 
        /// </summary>
        /// <param name="changePassword"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                var username = Session["Username"] as string;
                loginRepository.UpdatePassword(username, changePassword.NewPassword);
                return RedirectToAction("Signin", "Home");
            }
            return View(changePassword);
        }
    }
}