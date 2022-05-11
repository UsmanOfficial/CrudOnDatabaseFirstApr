using CrudOnDatabaseFirstApr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudOnDatabaseFirstApr.Controllers
{
    public class CustomerApiController : ApiController
    {
        DemoEntities1 db = new DemoEntities1();

        [HttpGet]
        public IHttpActionResult Get()
        {
            db.Customers.ToList();
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post(Customer customer)
        {
            db.Customers.Add(customer);
            int check = db.SaveChanges();
            if (check > 0)
            {
                return Ok("Data Inserted Successfully");
            }
            else
            {
                return Ok("Data not Inserted");
            }
        }
        [HttpPut]
        public IHttpActionResult Put(Customer customer, int id)
        {
            var customers = db.Customers.Where(e => e.ID == id).FirstOrDefault();
            customers.Name = customer.Name;
            customers.Designation = customer.Designation;
            customers.Salary = customer.Salary;
            int check = db.SaveChanges();
            if (check > 0)
            {
                return Ok("Data Updated Successfully");
            }
            else
            {
                return Ok("Data not Updated");
            }

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var data = db.Customers.Where(e => e.ID == id).FirstOrDefault();
            db.Customers.Remove(data);
            int check = db.SaveChanges();
            if (check > 0)
            {
                return Ok("Data Deleted Successfully");
            }
            else
            {
                return Ok("Data not Deleted");
            }
        }
    }
}
