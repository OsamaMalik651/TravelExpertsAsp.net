using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Experts__Workshop_4.Domain
{
    public class CustomerManager
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = null;
            TravelExperts_Context db = new TravelExperts_Context();
            customers = db.Customers
                .Include(m=> m.Bookings)
                .Include(m=> m.Agent)
                .ToList();
            return customers;

        }
        public static Customer Find(int id)
        {
            TravelExperts_Context db = new TravelExperts_Context();
            Customer customer = db.Customers.Find(id);
            return customer;
        }

    }
}
