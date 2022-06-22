using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private MyDBContext db = new MyDBContext();

        int x;


        // GET: Customer
        public ActionResult Index()
        {
            //Lambda Exp : var_name => this Var_name
            //var customers = getCustomers().ToList().Where(y => y.Id > 10);
            //return View(customers);
            // var customers = getCustomers();

            //   var customers = db.Customers.Include(c => c.MemberShipType).ToList();
            // return View(customers);

            return View();
        }
        //Get customer/details

        public ActionResult Details(int id)
        {
            var MemberShipTypes = db.MemberShipTypes.ToList();
            var Customer = getCustomers().SingleOrDefault(c => c.Id == id);
            if (Customer == null)
                return HttpNotFound();

            CustomerMemberShipViewModel cmsvm = new CustomerMemberShipViewModel
            {
                MemberShipTypes = MemberShipTypes,
                Customer = Customer
            };
            return View(cmsvm);


        }
        [HttpGet]
        public ActionResult Create()
        {
            var MemberShipTypes = db.MemberShipTypes.ToList();
            CustomerMemberShipViewModel cmsvm = new CustomerMemberShipViewModel
            {
                MemberShipTypes = MemberShipTypes
            };
            return View(cmsvm);
        }
        [HttpPost] //submit form
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerMemberShipViewModel cmsvm ) //bst2bl el form
        {
            var MemberShipTypes = db.MemberShipTypes.ToList();
            cmsvm.MemberShipTypes = MemberShipTypes;
            if (!ModelState.IsValid)
            {

                return View("Create",cmsvm);
            }
            db.Customers.Add(cmsvm.Customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        ///////////////////////////////////EDIT////////////////
        [HttpGet] //view el 2awly
        public ActionResult Edit(int id)
        {
            var Customer = db.Customers.Single(c => c.Id == id);//bgeeb el data bta3a el current cutomer

            var MemberShipTypes = db.MemberShipTypes.ToList();
            CustomerMemberShipViewModel cmsvm = new CustomerMemberShipViewModel
            {
                MemberShipTypes = MemberShipTypes,
                Customer=Customer
            };
            return View(cmsvm);
        }
        [HttpPost]
        public ActionResult Edit(CustomerMemberShipViewModel cmsvm)
        {
            if (!ModelState.IsValid)
            {
                var MemberShipTypes = db.MemberShipTypes.ToList();
                cmsvm.MemberShipTypes = MemberShipTypes;

                return View("Edit", cmsvm);
            }

            var CustomerDb = db.Customers.Single(c => c.Id == cmsvm.Customer.Id);
            // H3ml overwrite
            CustomerDb.Name = cmsvm.Customer.Name;
            CustomerDb.BirthDate = cmsvm.Customer.BirthDate;
            CustomerDb.IsMale = cmsvm.Customer.IsMale;
            CustomerDb.MemberShipTypeID = cmsvm.Customer.MemberShipTypeID; //5letha ID

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id) //bst2bl el form
        {
            var Customer = db.Customers.Single(c => c.Id ==id);

            db.Customers.Remove(Customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IEnumerable<Customer> getCustomers() //h3ml function tgebly list of customer w b3d kda hwdeha ll view 3shan a3rdha...... IEnumerable Generic data type//
        {
            /*
            List<Customer> customers = new List<Customer> //kol index 3bara 3n customer gdeed 
            {
                new Customer { Name = "saeed", Id = 55 },
                new Customer { Name = "abdelrhman", Id = 44 },
                new Customer { Name = "Atef", Id = 33 },
                new Customer { Name = "Mohamed", Id = 10 }
            };
            return customers;
            */
            var customers = db.Customers.ToList();
            return customers;

        }



    }
}