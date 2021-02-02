using Business.Abstract;
using Business.Concrete;
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
            ICarService carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("-----------------------Tüm arabalar listeleniyor----------------------------------");

            GetAllList(carManager);

            Console.WriteLine("------------------Id si belirtilen araba yazdırılıyor-------------------------------");

            Car car1 = carManager.GetById(2);
            PrintSingleElement(car1);

            Console.WriteLine("-----------------Araba güncelleştiriliyor ve yazdırılıyor---------------------------");

            car1.DailyPrice = 240.900;
            carManager.Update(car1);
            PrintSingleElement(car1);

            Console.WriteLine("-----------------Araba listeden silinip araba listesi tekrar yazdırılıyor---------------");

            carManager.Delete(car1);
            GetAllList(carManager);

            Console.WriteLine("-----------------Yeni araba eklendikten sonra liste yazdırılıyor----------------------");

            Car newCar = new Car();
            newCar.Id = 7;
            newCar.BrandId = 7;
            newCar.ColorId = 7;
            newCar.ModelYear = 2021;
            newCar.DailyPrice = 247.500;
            newCar.Description = "Peugeot Allure";
            carManager.Add(newCar);

            GetAllList(carManager);
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
