﻿using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext :DbContext //contains all the base methods and actions for our DataContext to work
    {
        public DataContext()
            : base("DefaultConnection") //calls the default connection within the connection string of Web.config OR App.config file
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

    }
}
