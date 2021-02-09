using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IBaseService<T> where T: IEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
