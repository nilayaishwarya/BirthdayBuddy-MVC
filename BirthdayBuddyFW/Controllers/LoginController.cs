using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirthdayBuddyFW.Models;
using System.Web.Mvc;

namespace BirthdayBuddyFW.Controllers
{
    public class LoginController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            // Here you have to make DB call (insert krn ahai)
            ViewBag.Message = null;
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register registerRequest)
        {
            // Here you have to make DB call (insert krn ahai)
            Request req = new Request();
            bool isValid = req.ValidateUser(registerRequest);

            if (isValid)
            {
                ViewBag.Message = String.Format("User exists");
                return View();
                //RedirectToAction("Register");
            }


            if (!isValid)
            {
                var response = req.Register(registerRequest);
                return RedirectToAction("SignIn");
            }
            return View();
        }

        [HttpGet]
        //[Route("/Login/Register")]
        public ActionResult SignIn()
        {

            // Here you have to make DB call (insert krn ahai)
            ViewBag.Message = null;
            return View();
        }
        [HttpPost]
        //[Route("/Login/Register")]
        public ActionResult SignIn(Login loginRequest)
        {

            // Here you have to make DB call (insert krn ahai)
            Send req = new Send();
            bool isValid = req.ValidateUser(loginRequest);

            if (isValid)
            {
                int level = req.ValidateUserLevel(loginRequest);
                if (level == 1)
                {
                    Session["UserName"] = loginRequest.UserName;
                    return RedirectToAction("Index", "Home");       //-------Login found
                }
                else
                {
                    Session["UserName"] = loginRequest.UserName;
                    return RedirectToAction("Index", "BuddyInfo");
                }
            }


            if (!isValid)
            {
                ViewBag.Message = String.Format("User not found");
                return View();            //--------- Not found
            }
            return View();
        }



        public ViewResult UserMessagePage()
        {
            return View();
        }

        [HttpGet]
        public string Hi(string name)
        {
           
            return "Hello "+ name + " !";
        }
    }
}