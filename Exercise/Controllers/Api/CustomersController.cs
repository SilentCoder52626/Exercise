using AutoMapper;
using Exercise.Dtos;
using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Exercise.Models.IdentityModel;

namespace Exercise.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext context;
        public CustomersController()
        {
            context = new ApplicationDbContext();
        }
        //GET api/customers
        public IEnumerable<CustomersDto> GetCustomers()
        {
            return context.Customers.Include(c=> c.MembershipType)
                .ToList().Select(Mapper.Map<Customers,CustomersDto>);
        }

        //GET api/customers/id
        public CustomersDto GetCustomers(int id)
        {
            var customers = context.Customers.SingleOrDefault(c => c.Id == id);

            if(customers == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customers,CustomersDto>(customers);
        }

        //Post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomersDto customersDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customers = Mapper.Map<CustomersDto, Customers>(customersDto);
            context.Customers.Add(customers); 
            context.SaveChanges();
            customersDto.Id = customers.Id;

            return Created(new Uri(Request.RequestUri + "/" + customers.Id),customersDto);
        }

        //Put /api/customers/id

        public void UpdateCustomers(int id, CustomersDto customersDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerInDB = context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customersDto, CustomerInDB);
            
            context.SaveChanges();
        }
        //DELETE /api/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDB = context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Customers.Remove(CustomerInDB);
            context.SaveChanges();
        }
    }
}
