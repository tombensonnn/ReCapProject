using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 25000, Description = "red(For Sale)", ModelYear = "2005"},
                new Car(){Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 30000, Description = "blue(For Sale)", ModelYear = "2006"},
                new Car(){Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 100000, Description = "white(For Sale)", ModelYear = "2017"},
                new Car(){Id = 4, BrandId = 2, ColorId = 4, DailyPrice = 40000, Description = "black(For Sale)", ModelYear = "2008"},
                new Car(){Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 55000, Description = "red(For Sale)", ModelYear = "2009"},
            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carForDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);

            _cars.Remove(carForDelete);
        }

       

        public List<Car> GetAll()
        {
            return _cars;
        }

       

        public List<Car> GetByBrandId(int brandId)
        {
            var carByBrandId = _cars.Where(c=>c.BrandId == brandId).ToList();

            return carByBrandId;
        }

        public void GetById(int id)
        {
            Car carById = _cars.SingleOrDefault(c=>c.Id == id);

            Console.WriteLine(carById.Description);
        }

        public void Update(Car car)
        {
            Car carForUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carForUpdate.BrandId = car.BrandId;
            carForUpdate.ColorId = car.ColorId;
            carForUpdate.DailyPrice = car.DailyPrice;
            carForUpdate.Description = car.Description;
            carForUpdate.ModelYear = car.ModelYear;
        }
    }
}
