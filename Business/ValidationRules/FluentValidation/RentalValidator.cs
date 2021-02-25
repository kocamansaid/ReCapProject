using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.RentDate).GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Geçmiş günler için araba kiralayamazsınız");
            RuleFor(p => p.CarId).NotEmpty().WithMessage("Olmayan araba kiralanamaz");
            RuleFor(p => p.ReturnDate).GreaterThanOrEqualTo(p => p.RentDate)
                .WithMessage("Rent date must be earlier than return date");
        }
    }
}
