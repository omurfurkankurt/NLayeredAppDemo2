using Northwind.Entities2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities2.Concrete
{
    public class Category:IEntity // Category sınıfına IEntity implemente etik
    {
        public int CategoryId { get; set; }       
        public string CategoryName { get; set; }

    }
}
