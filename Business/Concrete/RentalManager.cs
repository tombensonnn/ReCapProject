﻿using Business.Abstract;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {

            if (entity.ReturnDate == null)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }


            _rentalDal.Add(entity);

            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);

            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id == id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);

            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}