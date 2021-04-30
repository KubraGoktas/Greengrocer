using FluentValidation;
using Greengrocer.Business.Abstract;
using Greengrocer.Entity.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.Business.Validations.Product
{
    public class AddProductValidator:AbstractValidator<ProductAddDto>
    {
        public readonly IProductService _productService;
        public AddProductValidator(IProductService productService)
        {
            _productService = productService;

            RuleFor(p => p.Name).NotEmpty().WithMessage("ürün adı boş geçilemez");
            RuleFor(p => p.Name).MaximumLength(50).WithMessage("ürün adı 50 karakterden fazla olamaz");
            RuleFor(p => p.Price).NotEmpty().WithMessage("ürün fiyatı boş geçilemez");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("kategory ıd boş geçilemez");
            RuleFor(p => p.CategoryId).Must(ValidCategoryId).WithMessage("bu ıd ile kategori bulunamadı");

        }

        private bool ValidCategoryId(int CategoryId)
        {
            return _productService.ControlCategory(CategoryId);
        }
    }
}
