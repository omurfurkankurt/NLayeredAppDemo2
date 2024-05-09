using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business2.Abstract
{
    // İş katmanında ürün işlemlerinin genel arayüzünü sağlar.
    public interface IProductService
    {
       

        // Veritabanından tüm ürünleri getirmek için kullanılır.
        List<Product> GetAll();
        List<Product> GetProductsByCategory(int categoryId);  // seçilen verinin katakori Id sine göre veriyi getir
        List<Product> GetProductsByProductName(string ProductName);// ürün ismine göre arama
        void Add(Product product);         // Producta özeliklerine göre ürün eklem

        void Update(Product product); // Producta özeliklerine göre  ürün güncellem
        void Delet(Product product); // product özeliklerine göre ürün silme
    }
}
