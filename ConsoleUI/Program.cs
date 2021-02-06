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

            Car car1 = new Car() {Id = 3 , BrandId = 4 , ColorId = 3 , ModelYear = "2012", DailyPrice = 180000 ,  Description = "For Sale"};

            Car car2 = new Car() {Id = 4 , BrandId = 3 , ColorId = 3 , ModelYear = "2011" , DailyPrice = 170000  , Description = "For Sale"};



            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }


            //Console.WriteLine("Araba işlem simülasyonuna hoşgeldiniz.\nAşağıda yapabileceğiniz işlemler numaralara göre sıralanmıştır. Lütfen yapmak istediğiniz işlemi giriniz\n");

            //Console.WriteLine("1 - EKLEME\n2 - SİLME\n3 - GÜNCELLEME\n4 - LİSTELEME\n5 - MARKA ID'YE GÖRE LİSTELEME\n6 - RENK ID'YE GÖRE LİSTELEME\n");

            //Console.WriteLine("Lütfen yapmak istediğiniz işlem numarasını seçiniz");

            //int option = Convert.ToInt32(Console.ReadLine());

            //while (true)
            //{
            //    if (option == 1)
            //    {
            //        carManager.Add(car2);
            //    }

            //    else if (option == 2)
            //    {
            //        carManager.Delete(car2);
            //    }

            //    else if (option == 3)
            //    {
            //        carManager.Update(car2);
            //    }

            //    else if (option == 4)
            //    {
            //        foreach (var car in carManager.GetAll())
            //        {
            //            Console.WriteLine(car.Description);
            //        }
            //    }

            //    else if (option == 5)
            //    {
            //        carManager.GetCarsByBrandId(car1.BrandId);
            //    }

            //    else if (option == 6)
            //    {
            //        carManager.GetCarsByColorId(car1.ColorId);
            //    }

            //    else
            //    {
            //        Console.WriteLine("Yanlış bir seçim yaptınız.");
            //    }

            //    break;

            //}
        }
    }
}
