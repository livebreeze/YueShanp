﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YueShanp.Models;
using YueShanp.Models.Interface;

namespace YueShanp.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ICustomerRepository customerRepository;

        public CustomersController()
        {
            this.customerRepository = new CustomerRepository();
        }

        // GET: Customers
        [AllowAnonymous]
        public ActionResult Index()
        {
            var customers = this.customerRepository.GetAll();
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = this.customerRepository.Get((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Fax,Address,Email,Purchaser")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                EntityHelper<Customer>.CreateBaseEntity(customer, User.Identity.Name);
                this.customerRepository.Create(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = this.customerRepository.Get((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Fax,Address,Email,Purchaser,Creator,CreateTime")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                EntityHelper<Customer>.EditBaseEntity(customer, User.Identity.Name);
                this.customerRepository.Update(customer);

                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = this.customerRepository.Get((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = this.customerRepository.Get(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            EntityHelper<Customer>.EditBaseEntity(customer, User.Identity.Name, EntityStatus.Deleted);
            this.customerRepository.Update(customer);
            //this.customerRepository.Delete(customer);

            return RedirectToAction("Index");
        }
    }
}
