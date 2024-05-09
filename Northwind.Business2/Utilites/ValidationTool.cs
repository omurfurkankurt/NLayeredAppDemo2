using FluentValidation;
using Northwind.Business2.ValidationRules.FluentValidation;
using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business2.Utilites
{
  public static class ValidationTool  // sıklıkla kulanılacagı için static olarak tanımlanır
    {
        public static void Validate(IValidator validator,object entity)        // static classın method ve digeri üyeleri static olmalıdır

        {
            var result = validator.Validate((IValidationContext)entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }

        } 
    }
}
