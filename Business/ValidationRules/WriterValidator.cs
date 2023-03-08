using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty()
                .WithMessage("Yazar Adını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterSurname)
                .NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz!").MinimumLength(3)
                .WithMessage("Lütfen en az 3 karakter girişi yapın!")
                .MaximumLength(20).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın!");
            RuleFor(x => x.WriterTitle)
                .NotEmpty().WithMessage("Yazar Unvanını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterAbout)
                .Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");
        }
    }
}
