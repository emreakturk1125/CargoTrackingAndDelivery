using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs;

namespace TekhnelogosInterviewProject.WebUI.ValidationRules
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Şifreyi Geçilemez!");
        }
    }
}
