using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(X => X.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz");
            RuleFor(X => X.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(X => X.Subject).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz.");
            RuleFor(X => X.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(X => X.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
        }
    }
}
