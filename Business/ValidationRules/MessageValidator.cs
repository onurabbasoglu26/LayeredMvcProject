using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu adı gerekmektedir.")
                .MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.")
                .MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayın.");

            RuleFor(x => x.MessageContent)
                .NotEmpty().WithMessage("Mesajı içeriği gerekmektedir.")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapın.");

            RuleFor(x => x.ReceiverMail)
                .NotEmpty().WithMessage("E-posta adresi gerekmektedir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi gerekmektedir.");
        }
    }
}
