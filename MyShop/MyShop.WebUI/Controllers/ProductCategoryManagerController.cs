using Myshop.Core.Models;
using MyShop.Core.Contracts;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        //Creating an instance of product Category repository
        IRepository<ProductCategory> context;

        //constructor that initializes the repository
        public ProductCategoryManagerController(IRepository<ProductCategory> context)
        {
            this.context = context;
        }
        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            //return a list of product Categories
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        //method to create a product Category
        //(display page to fill in product Category)
        public ActionResult Create()
        {
            ProductCategory productCategories = new ProductCategory();
            return View(productCategories);
        }

        // Method to have the product Categories posted in the database
        [HttpPost]
        public ActionResult Create(ProductCategory productCategories)
        {
            //check for data validation
            if (!ModelState.IsValid)
            {
                return View(productCategories);
            }
            else
            {
                context.Insert(productCategories);

                //save changes by calling commit Method
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        // Method to load the product categories from database
        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                //return view with the product category found
                return View(productCategory);
            }
        }

        //method that takes in product category to be edited
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                //update the List with new info
                productCategoryToEdit.Category = productCategory.Category;
             
                context.Commit();

                return RedirectToAction("Index");

            }
        }

        //Delete Method(loads the product category  in the database to be deleted)
        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);

            }
        }

        //Actual method that confirms the product to be deleted
        //and then deletes with user permission
        [HttpPost]
        [ActionName("Delete")] //----Alternative ActionName
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
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