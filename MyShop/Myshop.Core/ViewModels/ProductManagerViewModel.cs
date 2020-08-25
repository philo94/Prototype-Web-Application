using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.ViewModels
{
    public class ProductManagerViewModel
    {
        public Product Product { get; set; }

        //A list that is to be iterated from productCategory
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
