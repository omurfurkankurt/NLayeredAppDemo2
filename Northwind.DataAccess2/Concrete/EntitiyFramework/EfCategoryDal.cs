using Northwind.DataAccess2.Abstract;
using Northwind.DataAccess2.Concrete.EntityFramework;
using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Concrete.EntitiyFramework
{
    // Veritabanı işlemleri için Entity Framework kullanarak Category  nesneleriyle ilgili veritabanı işlemlerini yöneten sınıf.

    public class EfCategoryDal:EfEntityReopsitoryBase<Category,NorthwindContext>,ICategoryDal
    { // EfEntityReopsitoryBase sınıfından kalıtım alınarak, Category nesneleri için genel veritabanı işlemleri burada gerçekleştirilir.

        // Özel metodlar, alanlar veya yapılandırıcılar buraya eklenebilir.
    }
}
