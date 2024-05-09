using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Abstract

{   
    // ICategoryDal, Category nesneleri için CRUD işlemlerini gerçekleştiren bir arayüzdür.
    // Bu arayüz, IEntitiyRepository arayüzünden kalıtım alır ve Category tipindeki nesnelerle çalışır.
    public interface ICategoryDal:IEntitiyReopsitory<Category>
    {
        // ICategoryDal özel metotları buraya eklenebilir, ancak genellikle temel CRUD işlemleri için IEntitiyRepository arayüzü kullanılır.
    }
}
