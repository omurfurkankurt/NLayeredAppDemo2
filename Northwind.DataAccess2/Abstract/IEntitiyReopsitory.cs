using Northwind.Entities2.Abstract;
using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Abstract                                                         
{
    
    // Bu Koda Generic kulanmamamızın sebebi                                                 

    public interface IEntitiyReopsitory<T> where T : class ,IEntity,new()
        // generic T referans tipi olmalı IEntityden implemente edilmeli
        // aynı zmanda newlwnmeli IproductDalada iplemente edildi 
        // IEntityRepository, veritabanı işlemleri için genel CRUD
        // operasyonlarını içeren bir arayüzdür.
        // Bu arayüz, birçok farklı varlık (entity) için temel veritabanı operasyonlarını sağlar.
        // Generic olarak tanımlanan T, IEntity arayüzünden kalıtım almalıdır
        // ve new() ile parametre almalıdır.

    {

        List<T> GetAll(Expression<Func<T,bool>> filter = null);  // ben san bir t verecem dönüş trü olarak bool vereceksin kulancı isterse filteri
                                                                 // vermek zorunda degil filter vermese tüm ürünleri getirecek filter verirse verdigi filteri getireccek  
        T Get(Expression<Func<T, bool>> filter);  //  kesinlikle bi filter vermek zorunda neye göre ürün getisin                 
        void Add(T entity);      // Belirli bir filtreye göre varlığı (entity) getiren Get metodu.Tek bir varlık getirir. Eğer varlık bulunmazsa null döndürür.

        void Update(T entity);
        void Delete(T entity);
    }
}







// Belirli bir filtreleme, genellikle veritabanından belirli koşulları karşılayan verilerin seçilmesi anlamına gelir.
// Bu, veri tabanından veri alırken belirli bir şartı sağlayan veya belli bir kriteri karşılayan verileri seçmek için kullanılır.

// Örneğin, bir veri tabanında bulunan ürünlerin listesinden yalnızca belirli bir kategoriye ait olanları veya belirli bir fiyat aralığında
// olanları çekmek istediğinizi düşünelim. Bu durumda, bir filtre kullanarak veritabanından yalnızca belirli koşulları karşılayan ürünleri seçebilirsiniz.

// Filtreleme işlemi, genellikle LINQ (Language Integrated Query) veya SQL sorgularıyla gerçekleştirilir. LINQ,
// C# gibi programlama dillerinde veri sorgulamak için kullanılan bir dil yapısıdır ve filtreleme işlemlerini kolayca
// gerçekleştirmeye olanak sağlar. Bu sorgularla belirli koşulları karşılayan veriler seçilebilir ve bu veriler üzerinde işlemler yapılabilir. 
// Bu sayede istenilen verilerin daha spesifik bir şekilde çekilmesi sağlanır.





