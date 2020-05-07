using CustomerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Domain
{
    public class CustomerDomain
    {
        public List<Customers> LoginCustomer(Customers customer)
        {
            using (var customerContext = new CustomerAppContext())
            {
                var result = customerContext.Customers.Where(cust => cust.Email == customer.Email && cust.Password == customer.Password).ToList();
                    return result;
                
            }
        }
        public void AddCustomer(Customers customer)
        {
            using (var customerContext = new CustomerAppContext())
            {
                Random rand = new Random();
                customer.CustomerNumber = rand.Next();
                customerContext.Customers.Add(customer);
                customerContext.SaveChanges();
            }
        }

        public void UpdateCustomer(Customers customer)
        {
            using (var customerContext = new CustomerAppContext())
            {
                customerContext.Customers.Update(customer);
                customerContext.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerid)
        {
            using(var customerContext=new CustomerAppContext())
            {
                Customers customer = new Customers();
                customer.CustomerId = customerid;
                customerContext.Customers.Remove(customer);
                customerContext.SaveChanges();
            }
        }     
    }
}
