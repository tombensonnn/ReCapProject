using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var addedCar = context.Entry(entity);
                addedCar.State = EntityState.Added;


                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    Console.WriteLine("Bu arabayı ekleyemezsiniz! Lütfen başka id ile deneyin.");
                }
            }
        }

        public void Delete(Car entity)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    Console.WriteLine("Böyle bir araba bulunmamaktadır.");
                }
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
