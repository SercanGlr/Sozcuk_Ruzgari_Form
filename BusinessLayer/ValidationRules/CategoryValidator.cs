using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(X => X.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(X => X.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(X => X.CategoryName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz.");
            RuleFor(X => X.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
        }
    }
}
