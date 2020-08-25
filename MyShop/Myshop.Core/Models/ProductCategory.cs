using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
    //Implements BaseEntity
    public class ProductCategory : BaseEntity
    {
        //public string Id { get; set; }
        public string Category { get; set; }

        /* public ProductCategory()
         {
             this.Id = Guid.NewGuid().ToString();
         }
         Getting rid of this constructor cos the Id has already been created in the BaseEntity class
         */
    }
}
