using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Abstract
{
    // IProductDal, Product varlığı için veri erişim metodlarını içeren arayüzdür.
    // Bu arayüz, Product varlığı için CRUD operasyonlarını sağlar.
    public interface IProductDal : IEntitiyReopsitory<Product>  // IEntitiyReopsitory özeliklerini IProductDal'a implemnte etik
                                                                // IEntitiyReopsitory'de Product özeliklerini verdik                                                                
    {
        

    }
}
//    Bu arayüz, IEntitiyReopsitory<Product> arayüzünden kalıtım alır ve bu şekilde Product varlığı için genel CRUD 
//    (Create, Read, Update, Delete) operasyonlarını sağlar. Ancak, bu arayüzün içeriğine özgü metodların
//    dökümantasyonunu içermez, bunlar genellikle IEntitiyReopsitory arayüzünde tanımlanmıştır. Bu nedenle,
//    IProductDal arayüzü daha çok genel operasyonları içeren bir arayüz olarak tasarlanmıştır.





