using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(p => p.FirstName).MinimumLength(8).WithMessage("Şifreniz en az sekiz karakter olmalıdır");
            


        }

    }
}
