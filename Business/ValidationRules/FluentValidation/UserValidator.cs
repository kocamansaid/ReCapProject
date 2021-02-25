using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Password).MinimumLength(8).WithMessage("Şifreniz en az sekiz karakter olmalıdır");
            


        }

    }
}
