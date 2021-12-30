using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SellValidator : AbstractValidator<Sell>
    {
        public SellValidator()
        {
            RuleFor(x => x.ServerIP).NotEmpty().WithMessage("Tutar Kısmı Boş Geçilemez!");
            RuleFor(x => x.ServerIP).MaximumLength(15).WithMessage("Server IP 15 karakterden fazla olamaz. Örneğin: 192.192.192.192");
            RuleFor(x => x.ServerIP).MinimumLength(7).WithMessage("Server IP 7 karakterden az olamaz. Örneğin: 1.1.1.1");

            RuleFor(x => x.StorageSize).NotEmpty().WithMessage("Depolama Alanı Boş Geçilemez!");

            RuleFor(x => x.SellValue).NotEmpty().WithMessage("Tutar Kısmı Boş Geçilemez!");
            RuleFor(x => x.SellValue).GreaterThan(0).WithMessage("Satış tutarı 0'ten fazla olmalıdır.");
        }
    }
}
