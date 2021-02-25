using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarId).GreaterThanOrEqualTo(0);
            RuleFor(p => p.Descriptions).MinimumLength(2);
            RuleFor(p => p.ModelYear).GreaterThan(2000);
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(2010).When(p=>p.BrandId==3);
            RuleFor(p => p.Descriptions).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
