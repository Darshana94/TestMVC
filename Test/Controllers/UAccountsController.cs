using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Test.Models;

namespace Test.Controllers
{
    public class UAccountsController : Controller
    {
        // GET: UAccount
        public ActionResult Index()
        {
            using(DemoEntities db = new DemoEntities())
            {
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(user account)
        {
            if (ModelState.IsValid)
            {
                using (DemoEntities db = new DemoEntities())
                {
                    db.users.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Massage = account.FirstName + "Successfully Registered.";
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user us)
        {
            using (DemoEntities db = new DemoEntities())
            {
                var usr = db.users.Single(v => v.Username == us.Username && v.Password == us.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.Username.ToString();
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong!");

                }
            }
                return View();
        }
        public ActionResult Home()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "UAccounts");
        }
    }
}