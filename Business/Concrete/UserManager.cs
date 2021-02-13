using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            if (entity.FirstName.Length < 2 && entity.LastName.Length < 3)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }

            _userDal.Add(entity);

            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);

            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.Listed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id == id));
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);

            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
