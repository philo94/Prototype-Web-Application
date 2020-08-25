using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productsCategories;

        public ProductCategoryRepository()
        {
            // check to see if a cache "Product Categories" exist, else create the cache
            productsCategories = cache["productsCategories"] as List<ProductCategory>;
            if (productsCategories == null)
            {
                productsCategories = new List<ProductCategory>();
            }
        }

        //Method that persist a product Category/Group instead of adding 
        //into the list until necessary
        public void Commit()
        {
            cache["productsCategories"] = productsCategories;
        }

        //Method to insert into Product Category List
        public void Insert(ProductCategory p)
        {
            productsCategories.Add(p);
        }

        //Method to Update the Product List
        public void Update(ProductCategory productCategory)
        {
            //Look into database to find a product Category to be updated
            ProductCategory productCategoryToUpdate = productsCategories.Find(p => p.Id == productCategory.Id);

            if (productsCategories != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        //Method to find a product Category in a database
        public ProductCategory Find(String Id)
        {
            ProductCategory ProductCategory = productsCategories.Find(p => p.Id == Id);

            if (ProductCategory != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }

        }

        //Method to Return list of product Categories
        public IQueryable<ProductCategory> Collection()
        {
            return productsCategories.AsQueryable();
        }


        //Method to delete a Product Category from List
        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productsCategories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                productsCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }
    }
}
