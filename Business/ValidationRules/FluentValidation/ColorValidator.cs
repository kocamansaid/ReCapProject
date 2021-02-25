using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).MinimumLength(2).WithMessage("Renk İsmi en az iki karakter olmalıdır");
        }

    }
}
