using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add using statements
using System.Runtime.Caching;
using Myshop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            // check to see if a cache "Products" exist, else create the cache
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        //Method that persist a product instead of adding 
        //into the list until necessary
        public void Commit()
        {
            cache["products"] = products;
        }

        //Method to insert into Product List
        public void Insert(Product p)
        {
            products.Add(p);
        }

        //Method to Update the Product List
        public void Update(Product product)
        {
            //Look into database to find product to be updated
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        //Method to find a product in a database
        public Product Find(String Id)
        {
            Product product = products.Find(p => p.Id ==Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        //Method to Return list of products
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }


        //Method to delete Product from List
        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
