using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntifyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // carManager instance oluşturuldu
            ICarService carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car {BrandId=4,ColorId=3,ModelYear=2005,DailyPrice=123.345,Description="araba-2"});
            GetAllList(carManager);

            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.Description);
            //}

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}

        }

        private static void PrintSingleElement(Car car)
        {
            Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                                car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
        }

        private static void GetAllList(ICarService carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                     car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);

            }
        }
    }
}
