using Northwind.DataAccess2.Abstract;
using Northwind.DataAccess2.Concrete.EntitiyFramework;
using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//Evet, ProductDal sınıfı içindeki GetAll metodu, NorthwindContext içindeki Products veri tabanı tablosundan tüm ürünleri çekmek için
//kullanılır. GetAll metodunun içindeki context.Products.ToList() ifadesi, NorthwindContext içindeki tüm ürünleri liste halinde döndürür.

//Bu durumda, GetAll metodunu kullanarak ProductDal sınıfı içinde NorthwindContext üzerinden tüm ürünleri çekebilirsiniz. Get metodu ise
//belirli bir id ile NorthwindContext içindeki Products tablosundan ilgili ürünü almak için kullanılır.

//Bu yapı, genellikle veritabanından veri çekerken ve bu verileri CRUD (Create, Read, Update, Delete) işlemlerinde kullanırken kullanışlıdır.
//Örneğin, Add, Update ve Delete metodları belirli bir Product nesnesini eklemek, güncellemek veya silmek için kullanılabilir.

//Add metodunda context.Products.Add(product) ile belirtilen product nesnesi, Products tablosuna eklenir ve SaveChanges() metodu çağrılarak
//bu değişiklikler kalıcı hale getirilir.

//Update metodunda ise mevcut bir product nesnesi üzerinde değişiklik yapılıp SaveChanges() ile bu değişikliklerin kaydedilmesi
//amaçlanmış olabilir. Ancak, veri tabanında güncelleme yapılacak öğenin nasıl seçileceği belirtilmemiş gibi görünmektedir.
//Bu sebeple, güncelleme işlemi için öncelikle ilgili öğe bulunup sonra güncelleme yapılması gerekebilir.

//Delete metodunun henüz tamamlanmadığını fark ettim. Bu metodun içeriğinin, veritabanından bir ürünün silinmesi işlemini
//gerçekleştirecek şekilde tamamlanması gerekecektir.

//Genel olarak, ProductDal sınıfı, veri tabanı işlemlerini yapan metodları içerir ve NorthwindContext kullanarak bu işlemleri gerçekleştirir.

namespace Northwind.DataAccess2.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityReopsitoryBase<Product, NorthwindContext>, IProductDal
    //ben burda Product ile çalışıyorum contexim ise NorthwindContext
    // yani EfProductDalı çalıştırdıgım zaman EfProductDal implemte etiklerimi kulanarak bana
    // NortwindContexte bulunan verileri getir Producta sınıfında bulunan özeliklere göre (properties)
    //EfEntityReopsitoryBase classını kulanrak

    {


    }
}
