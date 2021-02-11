using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            ColorManager colorManager = new ColorManager(new EfColorDal());

            BrandManager brandManager = new BrandManager(new EfBrandDal());


            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

            //Console.WriteLine("--------------------------------------------");

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            //Console.WriteLine("--------------------------------------------");


            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.CarName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            //Console.WriteLine("--------------------------------------------");

            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine("{0} {1} {2} {3}",car.BrandName,car.CarName,car.ColorName,car.DailyPrice);
            //}


        }
    }
}
