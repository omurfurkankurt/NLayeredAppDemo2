using FluentValidation;
using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business2.ValidationRules.FluentValidation
{
    //internal class ProductValidator : AbstractValidator<Product> // Product için kuralar 
    //{ //fluent validation özeliklere bakabilirsin tr destekliyor
    //    public ProductValidator()
    //    {
    //        RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz"); // mesaj özeligi
    //        RuleFor(p => p.CategoryId).NotEmpty(); // NotEmpty = Boş olamz 
    //        RuleFor(p => p.UnitPrice).NotEmpty();
    //        RuleFor(p => p.QuantityPerUnit).NotEmpty();
    //        RuleFor(p => p.UnitsInStock).NotEmpty();

    //        RuleFor(p => p.UnitPrice).GreaterThan(0); // p için pnin UnitPrice boş olamaz ve 0 dan byük olmalı 
    //        RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0); // Ürün stokta yok 
    //        RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);// categorID 2 se fiyatı 10 dan büyük olmalı
    //        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün Adı A ile başlamalı"); // bütün ürünlerin ismi A ile başlamlı

    //    }
    //    private bool StartWithA(string arg)
    //    {
    //        return arg.StartsWith("A");
    //    }
    //}
}
