using Northwind.DataAccess2.Abstract;
using Northwind.DataAccess2.Concrete.EntityFramework;
using Northwind.Entities2.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Concrete.EntitiyFramework
{
    // TEntity türündeki varlıkların temel veritabanı işlemlerini yönetmek için genel bir Entity Framework deposu sağlayan sınıf.

    public class EfEntityReopsitoryBase<TEntity, TContext> : IEntitiyReopsitory<TEntity>//EfEntityReopsitoryBase<TEntity, TContext>: Bu kısım, EfEntityReopsitoryBase
                                                                                        //sınıfının TEntity ve TContext adında iki parametre alacağını belirtir.Bu parametreler,
                                                                                        //sınıf içinde kullanılabilir ve genel olarak sınıfın davranışını ve türlerini belirler.

       where TEntity : class, IEntity, new()         // TEntity'nin bir sınıf, IEntity'den türetilmiş ve parametresiz bir yapılandırıcıya sahip olması gerekiyor.
       where TContext : DbContext, new()             // TContext'in DbContext'ten türetilmiş ve parametresiz bir yapılandırıcıya sahip olması gerekiyor.
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // CONTEXTE Insort Update delete için Entry metodu ile veri tabanında bulunan
                                                         // ilgili nesneye erişecek kodu yazmak için kulanılır
                addedEntity.State = EntityState.Added;   // benim  veri tabanımdaki nesneye abone ol bu nesne yeni bir nesne oldugu için
                                                         // bulamıcaksın o yüzden bu yeni eklencek diye işaretliyoruz
                context.SaveChanges();                   // degişiklikleri veri tabanına eklemk için kulanılan method
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;  // Deleted Methodu: ilgili nesneye abone ol ama onu silinecek diye işartele 
                context.SaveChanges();                    
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                // TEnttiye Set ol gelen filter göre datayı getir get için
                // filteri zorunlu tutumuştuk IEntitiyReopsitorde 
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())         
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                // filter nullsa  TEntitye kendisini abone ediyor nulsa tüm verileri getir 
                // null degilse TEntityin where uygugul filteri kulanmak için verdigmiz filteri liste şeklinde getir

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;      // modified methodu: ilgili nesne veri tabınıda var ona abone ol gelen veriler göre güncelle
                context.SaveChanges();
            }
        }
    }
}
