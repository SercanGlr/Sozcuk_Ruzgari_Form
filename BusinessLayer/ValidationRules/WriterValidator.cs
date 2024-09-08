using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı boş geçilemez.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında kısmı boş geçilemez.");
            RuleFor(x => x.WriterTittle).NotEmpty().WithMessage("Ünvan kısmı boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalıdır.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olabilir.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E-posta adresi boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");
            RuleFor(x => x.WriterPassword).MaximumLength(20).WithMessage("Şifre en fazla 20 karakter olabilir.");
        }
    }
}
