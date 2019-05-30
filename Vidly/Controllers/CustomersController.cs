﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var vm = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", vm);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    var customerInDb = _context.Customers.Where(c => c.CustomerId == customer.CustomerId).Single();
                    customerInDb.CustomerName = customer.CustomerName;
                    customerInDb.BirthDate = customer.BirthDate;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            }
            else
            {
                return View("CustomerForm");
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            var membershipTypes = _context.MembershipTypes.ToList();
            var vm = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };

            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", vm);
        }


    }
}