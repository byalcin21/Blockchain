using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BalanceValidator:AbstractValidator<Balance>
    {
        public BalanceValidator()
        {
            RuleFor(x => x.BalanceValue).NotEmpty().WithMessage("Tutar Kısmı Boş Geçilemez!");
            RuleFor(x =>x.BalanceValue).GreaterThan(100).WithMessage("Para tutuarı 100'ten fazla olmalıdır.");
        }
    }
}
