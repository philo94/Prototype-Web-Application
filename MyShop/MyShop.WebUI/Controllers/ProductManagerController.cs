using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Adding references
using Myshop.Core.Models;
using Myshop.Core.ViewModels;
using MyShop.Core.Contracts;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        //Creating an instance of IRepository
       IRepository<Product> context;

        // Add the repository so that we can load the product categories from the database
        IRepository<ProductCategory> ProductCategories;

        //Initialize the product category
       

        //constructor that initializes the repository
        public ProductManagerController(IRepository<Product>productContext, IRepository<ProductCategory>productCategoryContext)
        {
            context = productContext;
            //Initialize the product category
            ProductCategories = productCategoryContext;
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
            //Update the create action to return a product with a list
            // of categories
            //create a reference to the viewModel
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.Product = new Product();
            viewModel.ProductCategories = ProductCategories.Collection();
            return View(viewModel);

          
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

        // Method to load the product and product category from database
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
                // return viewmodel(containing the product and the list of product categories)
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = ProductCategories.Collection();
                return View(viewModel);
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