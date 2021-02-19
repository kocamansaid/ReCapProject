using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.MakeSuccess);

        }

        public IResult Add(Brand brand)
        {

            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.NotMakeSucces);
            }
            
            _brandDal.Add(brand);
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update( brand );
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IDataResult<Brand> GetById(int id)
        {
            
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.MakeSuccess);
        }
    }
}
