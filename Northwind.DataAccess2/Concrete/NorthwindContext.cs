using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Concrete.EntityFramework
{
    //DbContext, Entity Framework'te bir veritabanı bağlantısını temsil eden ve
    //veri tabanı işlemlerini gerçekleştirmek için kullanılan bir sınıftır.
    //Bu sınıf, veritabanı ile ilişkilendirilmiş C# sınıflarını ve veritabanı
    //tablolarını yönetmek için kullanılır. DbContext sınıfı, veritabanı bağlantısını ve veri tabanı işlemlerini sağlar.
    public class NorthwindContext:DbContext
    {
        //NorthwindContext sınıfı içinde bulunan Products özelliği, Product sınıfının veritabanındaki karşılığı olan
        //bir DbSet'i temsil eder. DbSet, Entity Framework'te bir veritabanı tablosunu veya sorgusunu temsil eder.DbSet,
        //DbContext içinde bulunur ve veritabanındaki belirli bir tabloya karşılık gelir. Bu durumda, Products özelliği
        //Product sınıfının veritabanındaki kayıtlarını temsil eder ve NorthwindContext üzerinden bu kayıtlara erişim sağlar.

        public DbSet<Product>Products { get; set; } 
        public DbSet<Category>Categories { get; set; }
       
    }
}
