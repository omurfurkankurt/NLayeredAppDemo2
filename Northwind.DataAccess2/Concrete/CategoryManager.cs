using Northwind.DataAccess2.Abstract;
using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Concrete
{
    public class CategoryManager : ICategoryService // ICatagoryServiceyi CatagoryManagere implemete etik 
    {
        private ICategoryDal _categoryDal;    //ICategoryDal dan referans almak içn yeni bir degişken tanımlıyoruz
                                              //private degişken türünde oldugu için sadece bu projede kulanılabilir
        public CategoryManager(ICategoryDal categoryDal)
        {
                                                                // "Constructor"(kurucu metod), bir sınıfın örneklenmesi sırasında çağrılan özel bir metottur. 
                                                                //Bir sınıfın yapıcı metodudur ve genellikle o sınıfın nesnesi oluşturulurken çalışır.
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
           return _categoryDal.GetAll();
        }

        
    }
}
//Bu yapı, birçok veritabanı işlevselliğini soyut bir şekilde ele alır. ICategoryService ve ICategoryDal gibi arayüzler,
//    iş mantığının ve veri erişiminin ayrılmış olmasını sağlar. Bu da bir projenin geliştirilmesi, bakımı ve test edilmesi 
//    açısından faydalı olabilir. Bu kod, genellikle bir ORM (Object-Relational Mapping) aracılığıyla gerçek bir veritabanıyla 
//    etkileşimde bulunur veya elle SQL sorguları kullanarak veritabanı işlemlerini gerçekleştirir.





