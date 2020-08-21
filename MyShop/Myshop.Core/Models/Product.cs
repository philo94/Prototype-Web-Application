using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
   // public class to enable other programs and projects access its properties
    public class Product
    {
        public string Id { get; set; }

        //Data validation
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        //Data validation
        [Range(0, 1000)]
        public decimal Price { get; set; }

        //Group products into categories
        public string Category { get; set; }

        //contains URL for our product Image
        public string Image { get; set; }

        public Product()
        {
            //Id is created as string but generated as GUID
            this.Id = Guid.NewGuid().ToString();
        }
        
    }
}
