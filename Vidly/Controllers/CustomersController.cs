﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer{ CustomerId=1,CustomerName="Mike"},
                new Customer{ CustomerId=2,CustomerName="Josh"},
                new Customer{ CustomerId=3,CustomerName="Dave"},
                new Customer{ CustomerId=4,CustomerName="Rob"},
                new Customer{ CustomerId=5,CustomerName="Jon"}
            };
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = Customers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = Customers();
            var cust = customers.Where(c => c.CustomerId == id).FirstOrDefault();

            return View(cust);
        }
    }
}