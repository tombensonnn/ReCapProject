using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class , IEntity , new()
    {
        //class'tan kasıt referans tip olmasıdır 
        //IEntity implementasyonu olmalıdır ki metodlarımız entitylere göre kullanılsın
        //new() yazmamızın nedeni T yerine olası bir interface yazılmasını önlemektir

        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
