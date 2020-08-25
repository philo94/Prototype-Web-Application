using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Please note that this Class serves as a BASE class to the generic "InMemoryRepository"
namespace Myshop.Core.Models
{
    // by setting it as an abstract class, it means we cannot create an instance of its own
    // but as a class that exists to be implemented by another class
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        //Used for troubleshooting to identity when a particular class was created
        public DateTimeOffset CreatedAt { get; set; }

        //create a constructor to place an internal ID
        //and n instance of the Datetime the class was created
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}
