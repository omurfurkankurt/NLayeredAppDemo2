using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess2.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();  // Category döndüren method Category sınıfında verdigmiz IEntity implemnteisni kulanan
                                  // Category sınıfın IEntity kulanrak GetAll methoduyla katakorileri getiriyor
    }
}
