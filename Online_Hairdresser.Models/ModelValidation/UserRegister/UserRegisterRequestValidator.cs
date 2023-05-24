using FluentValidation;
using Online_Hairdresser.Models.Models.Request.UserRegister;

namespace Online_Hairdresser.Models.ModelValidation.UserRegister;

public class UserRegisterRequestValidator: AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("bad_request")
            .NotNull().WithMessage("bad_request");
        RuleFor(x => x.Name)
            .NotNull().WithMessage("bad_request");
        RuleFor(x => x.Surname)
            .NotNull().WithMessage("bad_request");
        RuleFor(x => x.City)
            .NotNull().WithMessage("bad_request");
        RuleFor(x => x.County)
            .NotNull().WithMessage("bad_request");
        RuleFor(x => x.Password)
            .NotNull().WithMessage("bad_request");
        RuleFor(x => x.Version)
            .NotNull().WithMessage("bad_request");
    }
}