using Myshop.Core.Models;
using Myshop.Core.ViewModels;
using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //Creating an instance of IRepository
        IRepository<Product> context;

        // Add the repository so that we can load the product categories from the database
        IRepository<ProductCategory> ProductCategories;

        //Initialize the product category


        //constructor that initializes the repository
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            //Initialize the product category
            ProductCategories = productCategoryContext;
        }
        public ActionResult Index(string Category =null)
        {
            List<Product> products;
            List<ProductCategory> categories = ProductCategories.Collection().ToList();

            if(Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Product = products;
            model.ProductCategories = categories;
            return View(model);
        }

        //method that creates the product page
        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}