using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.MakeSuccess);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id), Messages.MakeSuccess);

        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var find = _rentalDal.Get(p =>
                p.CarId == rental.CarId && (p.ReturnDate == null || p.ReturnDate > DateTime.Now));
            if (find != null)
            {
                return new ErrorResult(Messages.UnAvaliableCar);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.MakeSuccess);
            }
        }
    

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult( Messages.MakeSuccess);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult( Messages.MakeSuccess);
        }
    }
}
