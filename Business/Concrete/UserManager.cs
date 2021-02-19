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
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.MakeSuccess);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id), Messages.MakeSuccess);
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length <= 2)
            {
                return new ErrorResult(Messages.NotMakeSucces);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.MakeSuccess);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult( Messages.MakeSuccess);
        }

        public IResult Delete(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.MakeSuccess);
        }
    }
}
