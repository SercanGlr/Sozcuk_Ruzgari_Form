using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(X => X.ReceiverMail).NotEmpty().WithMessage("Alıcı Mail Adresini Boş Geçemezsiniz");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(X => X.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            RuleFor(X => X.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(X => X.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter giriniz.");
        }
    }
}
