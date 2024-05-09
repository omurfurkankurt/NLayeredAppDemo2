using Northwind.Entities2.Concrete;
using Northwind.DataAccess2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Business2.Concrete;
using Northwind.DataAccess2.Concrete.EntityFramework;
using Northwind.DataAccess2.Abstract;
using Northwind.Business2.Abstract;
using System.Data.Entity.Infrastructure;
using FluentValidation;
using Northwind.Business2.ValidationRules.FluentValidation;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;
using Northwind.Business2.Utilites;

//ProductManager sınıfı, ProductDal sınıfını kullanarak veri erişim işlemlerini yönetir.
//ProductDal sınıfındaki GetAll metodu, veritabanından tüm ürünleri almak için NorthwindContext kullanır.
//NorthwindContext içindeki Products tablosundan tüm veriler ToList() metodu ile bir liste olarak alınır.
//ProductManager sınıfı, ProductDal'daki GetAll metodu aracılığıyla elde edilen verileri alır 

namespace Northwind.Business2.Concrete      
{
    // Ürün işlemlerini yöneten sınıf.
    public class ProductManager: IProductService  // Ürün veri erişim katmanı arayüzü referansı

    { // private sadece tanımlandıgı class içinden erişilebilir
        private IProductDal _productDal;             // IProductDaldan referans almak için yeni bir değişken  tanımlıyoruz
                                                     // ilerleyen zamanda farklı bir veri tabnından veri almak istersek 
                                                     // aynı şeklde IProductDal dan referan alark kulanabilirz (Dependency Injection)bağımlılık enjeksiyonu 


        public ProductManager(IProductDal productDal)
                                                                      // productmanager newlwndigi zaman bana bir IProductDal türünde   
                                                                      // bir nesne ver (NHiberent olur Entityframework olur farketmez)
        {
            _productDal = productDal;          // Ürün veri erişim katmanı referansı atanır
  
        }

        public void Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
         

            _productDal.Add(product);   // parametre olarak gönderilen Product Ekle
        }
        public void Update(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Update(product);
        }

        public void Delet(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {
                throw new Exception(" Silme işlemi gerçekleşemedi");

            }
        }

        public List<Product> GetAll()
        {
            //Business code
            // İş katmanı kodları burada yer alabilir.

            // Ürün veri erişim katmanındaki GetAll metodu çağrılarak tüm ürünler alınır.
            // veri erişim katmanına IProductDal dan referansını olluşturdugmuz _productDalı kulanark erişiyoruz

            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId == categoryId); // her producta bak beni sana verdigim categoryId ile eşleşenleri döndür
        }

        public List<Product> GetProductsByProductName(string productName)
        {
           return _productDal.GetAll(p =>p.ProductName.ToLower().Contains(productName.ToLower()));
            // 
        }

       
    }
}










//private IProductDal _productDal; ifadesi, ProductManager sınıfı içinde _productDal isminde bir özel (private) alan tanımlar.
//Bu alan, IProductDal türünde bir değişkeni temsil eder.

//Bu değişken, ProductManager sınıfının bir üyesi olarak tanımlanmıştır. _productDal adındaki bu alan, IProductDal türünden bir nesneyi referanslamak için kullanılır.
//Yani, ProductManager sınıfı içindeki diğer metotlar veya özellikler tarafından erişilebilen bir alan olur.

//Bu tür bir yapı, genellikle bağımlılık enjeksiyonu (dependency injection) kavramıyla birlikte kullanılır.
// ProductManager sınıfı,bu alana atanan bir IProductDal türünden bir nesneye ihtiyaç duyar. Bağımlılık enjeksiyonu,
// bu gereksinimi karşılamak için sınıfın dışından bir nesne referansını bu alana atama işlemiyle gerçekleştirilir. 
//Bu sayede, ProductManager sınıfı IProductDal arayüzünden türetilmiş herhangi bir sınıfı kullanabilir ve bu sınıflar arasında geçiş yapılabilir hale gelir.

//Bu şekilde yapılandırılmış bir yapı, sınıflar arasında esneklik sağlar ve bağımlılıkları azaltarak kodun daha test edilebilir ve bakımı daha kolay hale getirir.
//Bu tip bir yapı, genellikle yazılımın modülerliğini ve genişletilebilirliğini artırmak için tercih edilir.