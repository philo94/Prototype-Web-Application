using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Adding references
using Myshop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        //Creating an instance of product repository
        ProductRepository context;

        //constructor that initializes the repository
        public ProductManagerController()
        {
            context = new ProductRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            //return a list of products
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        //method to create a product
        //(display page to fill in product details)
        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        // Method to have the product details posted in the database
        [HttpPost]
        public ActionResult Create(Product product)
        {
            //check for data validation
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);

                //save changes by calling commit Method
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        // Method to load the product from database
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                //return view with the product found
                return View(product);
            }
        }

        //method that takes in product to be edited
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                //update the List with new info
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                context.Commit();

                return RedirectToAction("Index");

            }
        }

        //Delete Method(loads the product in the database to be deleted)
        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);

            }
        }

        //Actual method that confirms the product to be deleted
        //and then deletes with user permission
        [HttpPost]
        [ActionName("Delete")] //----Alternative ActionName
        public ActionResult ConfirmDelete (string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                 return RedirectToAction("Index");

            }
        }
    }
}