using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail)
                .NotEmpty().WithMessage("Mail adresini boş geçemessiniz!");
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu adını boş geçemessiniz!")
                .MaximumLength(50).WithMessage("Lütfen fazla 50 karakter girişi yapın!")
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın!");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adını boş geçemessiniz!")
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın!");
        }
    }
}
