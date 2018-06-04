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
            GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();

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
            GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();
            ViewBag.UserList = ORM.Users.ToList();
            ViewBag.Message = "things are happening";
            return View();
        }
        public ActionResult AddNewUser(User NewUser)
        {

            if (ModelState.IsValid)
            {
                GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();

                ORM.Users.Add(NewUser);

                ORM.SaveChanges();

                ViewBag.Message = $"Welcome{NewUser.UserName}";
                return RedirectToAction("You are connected.");
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
        public ActionResult Admin()
        {
            GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();

            ViewBag.ItemList = ORM.Items.ToList();
            ViewBag.Message = "Itmes added!";

            return View();

        }
        public ActionResult AddItemDetails()
        {
            return View();
        }
        public ActionResult AddNewItem(Item NewItem)
        {
            GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();
            ORM.Items.Add(NewItem);

            ORM.SaveChanges();

            return RedirectToAction("Admin");
        }
        public ActionResult DeleteItem(string Name)
        {

            GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();

            //2. find the customer you want to delete
            Item Found = ORM.Items.Find(Name);
            //3 remove the customer
            if (Found != null)
            {
                //ToDo: delete all orders for that customer first
                ORM.Items.Remove(Found);
                //4 save to DB
                ORM.SaveChanges();
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Item not found";
                return View("Error");
            }
        }

        public ActionResult UpdateItemDetails (string Name)
        {
            GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();
            //2. Find the customer
            Item Found = ORM.Items.Find(Name);

            if (Found != null) 
            {
                return View(Found);
            }
            else
            {
                ViewBag.ErrorMessage = "Item Not Found";
                return View("Error");
            }
        }

        public ActionResult SaveItemUpdates(Item UpdateItemDetails)
        {
            GCCoffeeShopEntities ORM = new GCCoffeeShopEntities();
            Item oldItemRecord = ORM.Items.Find(UpdateItemDetails.Name);

            if (oldItemRecord != null && ModelState.IsValid)
            {
                oldItemRecord.Name = UpdateItemDetails.Name;
                oldItemRecord.Description = UpdateItemDetails.Description;
                oldItemRecord.Quantity = UpdateItemDetails.Quantity;
                oldItemRecord.Price = UpdateItemDetails.Price;
                ORM.Entry(oldItemRecord).State = System.Data.Entity.EntityState.Modified;
                ORM.SaveChanges();
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Customer Item Found";
                return View("Error");
            }
        }

    }
}