using Core.Entities;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IBaseService<T> where T: IEntity
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
