using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab23.Models;

namespace Lab23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GC_Coffee_ShopEntities ORM = new GC_Coffee_ShopEntities();

            ViewBag.ItemList = ORM.Items.ToList();
            ViewBag.Message = "Itmes added!";

            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserRegistration()
        {
            GC_Coffee_ShopEntities ORM = new GC_Coffee_ShopEntities();
            ViewBag.UserList = ORM.Users.ToList();
            ViewBag.Message = "things are happening";
            return View();
        }
        public ActionResult AddNewUser(User newUser)
        {
            
            if (ModelState.IsValid)
            {
                GC_Coffee_ShopEntities ORM = new GC_Coffee_ShopEntities();

                ORM.Users.Add(newUser);

                ORM.SaveChanges();

                ViewBag.Message = $"Welcome{newUser.UserName}";
                return RedirectToAction("Confirm");
            }
            else
            {
                ViewBag.Address = Request.UserHostAddress;
                return View("Error");
            }
        }
        public ActionResult Confirm()
        {
            ViewBag.Message = "Yhatzi, your information has been stored";
            return View();
        }
        public ActionResult ItemList()
        {
            GC_Coffee_ShopEntities ORM = new GC_Coffee_ShopEntities();

            ViewBag.ItemList = ORM.Items.ToList();
            ViewBag.Message = "Itmes added!";

            return View();
        }
    }
}