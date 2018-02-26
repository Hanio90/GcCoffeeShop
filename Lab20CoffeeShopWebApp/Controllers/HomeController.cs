using Lab20CoffeeShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20CoffeeShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            using (var db = new CoffeeShopDBEntities())
            {
                ItemList itemListModel = new ItemList();

                 itemListModel.ItemsList = db.Items.ToList();

                return View(itemListModel);
            }

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
        public ActionResult Register()
        {
            return View();
        }

        //public ActionResult WelcomeUser(string FirstName)
        //{
        //    ViewBag.Message = $"Welcome to the Grand Circus Coffee Shop, {FirstName}!";
        //    return View();
        //}

        public ActionResult WelcomeUser(User newUser) // New customer is an object of Customer 
        {
            // 1. Create an object from the ORM class
            CoffeeShopDBEntities MyORM = new CoffeeShopDBEntities(); // you need this object to talk to the Data base

            // 2.Validation

            // 3.Adding the new customer to Customers list using MyORM.
            MyORM.Users.Add(newUser);

            //4.Save changes
            MyORM.SaveChanges();


            ViewBag.Message = $"Welcome to the Grand Circus Coffee Shop, {newUser.FirstName}!";
              return View();
        }
        
    }
}