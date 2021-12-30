using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Kullanıcı Soyadı 2 Harften Küçük Olamaz.");

            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Kullanıcı Soyadı Boş Geçilemez!");
            RuleFor(x => x.UserSurname).MinimumLength(2).WithMessage("Kullanıcı Soyadı 2 Harften Küçük Olamaz.");

            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Kullanıcı Mail Bilgisi Boş Geçilemez!");
            RuleFor(x => x.UserMail).MinimumLength(8).WithMessage("Mail Adresi 8 Haneden Küçük Olamaz.");
            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Geçerli bir eposta adresi giriniz.").When(x => !string.IsNullOrEmpty(x.UserMail));

            RuleFor(x => x.TCNumber).NotEmpty().WithMessage("Kullanıcı Kimlik Bilgisi Boş Geçilemez!");
            RuleFor(x => x.TCNumber).MinimumLength(11).WithMessage("Kimlik Numarası 11 Haneli Olmak Zorundadır.");
        }
    }
}
