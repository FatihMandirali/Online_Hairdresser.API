using FluentValidation;
using Online_Hairdresser.Models.Models.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Models.ModelValidation.Login
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().WithMessage("Lütfen email alanını uygun doldurun");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Lütfen şifre alanını uygun doldurun");
        }
    }
}
