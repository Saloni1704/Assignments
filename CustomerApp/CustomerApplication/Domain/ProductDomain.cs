using CustomerApplication.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Domain
{
    public class ProductDomain
    {

        public List<Products> AllProduct(Products product)
        {
            using (var customerContext = new CustomerAppContext())
            {
                var data = customerContext.Products.Select(x =>x).ToList();
                return data;
            }
        }
        public void AddProduct(Products product)
        {

            using (var customerContext = new CustomerAppContext())
            {
                customerContext.Add(product);
                customerContext.SaveChanges();
            }
        }

        public void DeleteProduct(int productid)
        {
            using (var customerContext = new CustomerAppContext())
            {
                Products product = new Products();
                product.ProductId = productid;
                customerContext.Remove(product.ProductId);
                customerContext.SaveChanges();
            }
        }


        public void SearchProduct(Products product)
        {

            using (var customerContext = new CustomerAppContext())
            {
                var pr = customerContext.Database.ExecuteSqlCommand("spSearchProduct @Product",
                    new SqlParameter("@Product", product.ProductCode)
            );
         
            }
        }

        public void FilterProduct(Products product)
        {
            using (var customerContext = new CustomerAppContext())
            {
                var pr = customerContext.Database.ExecuteSqlCommand("spFilterProduct @Status",
                     new SqlParameter("@Status", product.ProductStatus)
                     );
            }       
        }
    }
}
