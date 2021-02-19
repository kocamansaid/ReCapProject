using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.MakeSuccess);
        }

        public IDataResult<Color> GetById(int id)
        {
            
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), Messages.MakeSuccess);
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.NotMakeSucces);
            }

            _colorDal.Add(color);
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.MakeSuccess);
        }
    }
}
