using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Inmemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.NotMakeSucces);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.MakeSuccess);
        }
        
        public IDataResult<Car> GetById(int id)
        {

            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id), Messages.MakeSuccess);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.MakeSuccess);

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IResult Delete(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.MakeSuccess);
        }

        public IDataResult<List<CarDetailDto>> getCarDetails()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.getCarDetail(), Messages.MakeSuccess);
        }
    }
}
