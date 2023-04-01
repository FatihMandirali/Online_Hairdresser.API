using FluentValidation;
using Online_Hairdresser.Models.Models.Request.UserRegister;

namespace Online_Hairdresser.Models.ModelValidation.UserRegister;

public class UserRegisterRequestValidator: AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotNull().WithMessage("Lütfen email alanını uygun doldurun");
        RuleFor(x => x.Name).NotNull().WithMessage("Lütfen ad alanını uygun doldurun");
        RuleFor(x => x.Surname).NotNull().WithMessage("Lütfen ad alanını uygun doldurun");
        RuleFor(x => x.City).NotNull().WithMessage("Lütfen şehir alanını uygun doldurun");
        RuleFor(x => x.County).NotNull().WithMessage("Lütfen ilçe alanını uygun doldurun");
        RuleFor(x => x.Password).NotNull().WithMessage("Lütfen şifre alanını uygun doldurun");
        RuleFor(x => x.Version).NotNull().WithMessage("Lütfen version alanını uygun doldurun");
    }
}