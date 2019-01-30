using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using static Exercise.Models.IdentityModel;
using Exercise.ViewModel;

namespace Exercise.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Customer

        public ActionResult CustomerForm()
        {
            var membershipType = context.MembershipTypes.ToList();
            var ViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipType
            };
            return View("CustomerForm",ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerFormViewModel(customer)
                {                    
                    MembershipTypes = context.MembershipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
            }
            if(customer.Id == 0 )
                context.Customers.Add(customer);
            else
            {
                var customerInDb = context.Customers.Single(c => c.Id== customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribed = customer.IsSubscribed;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                
                MembershipTypes = context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
        
        public ViewResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {   
            var customer = context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=> c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }        
    }
}

