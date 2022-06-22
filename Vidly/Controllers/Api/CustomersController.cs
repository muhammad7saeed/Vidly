using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }


        // GET /api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            // return _context.Customers.ToList().Select(Mapper.Map<Customer , CustomerDto>);
              var customerDtos =   _context.Customers
                  .Include(c=>c.MemberShipType)
                  .ToList()
                  .Select(Mapper.Map<Customer , CustomerDto>);
              return Ok(customerDtos);

        }
        //REplace customerDto b IHttpActionResult
        // GET /api/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Customer , CustomerDto>(customer));

        }

        // POST api/customers
        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer >(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

           // return customerDto ;
           return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }

        //PUT api/customers/1
        [HttpPut]
        public  IHttpActionResult updateCustomer (CustomerDto customerDto, int id)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
           // customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.Name = customerDto.Name;
            //customerInDb.IsMale = customerDto.IsMale;
            //customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            //customerInDb.MemberShipTypeID = customerDto.MemberShipTypeID;

            _context.SaveChanges();

            return Ok();

        }

        //DELETE api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();


        }














    }
}
