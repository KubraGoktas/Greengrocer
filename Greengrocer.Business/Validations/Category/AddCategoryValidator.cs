using FluentValidation;
using Greengrocer.Entity.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.Business.Validations.Category
{
    public class AddCategoryValidator:AbstractValidator<CategoryAddDto>
    {
        public AddCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("kategori ismi boş geçilemez");
            RuleFor(p => p.Name).MaximumLength(50).WithMessage("kategori ismi 50 karakterden fazla olamaz");

        }
    }
}
