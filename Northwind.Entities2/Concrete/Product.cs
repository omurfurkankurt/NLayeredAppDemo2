using Northwind.Entities2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities2.Concrete
{// Bu C# kodu, Northwind.Entities2.Concrete namespace   Product adında bir class tanımlar.
 // Bu class, ürünlerin özelliklerini temsil eder (ürün ID'si, adı, kategori ID'si, birim fiyatı, miktarı ve stoktaki birim sayısı).
    public class Product:IEntity       
                                  // Bir nesne veritabanı nesnesi ise IEntityden impenmente edilsin imzalama amaçlı içinde IEntityde
                                 // içinde bişey olması gerkemz ama oladabilir kulanıcıyı yazarken bilgilendirmek amaçlı
                                 //implemte edilmezse bir veri tabanı nesnesi gibi durmuyor gibisinden

    { // Product sınıfı, ürün özelliklerini içeren public özelliklere (properties) sahiptir.
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int  CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public Int16 UnitsInStock { get; set; }
    }
}
