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
            // GetAll() ile Tüm arabalar listeleniyor
            
            foreach (var car in carManager.GetAll())
            {
               Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                    car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);               
                
            }


            Console.WriteLine("------------------Id si belirtilen araba yazdırılıyor-------------------------------");


            // GetById ile belirtilen id de araba listeden alınıyor.
            Car car1 = carManager.GetById(2);
            
            Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                    car1.Id, car1.BrandId, car1.ColorId, car1.ModelYear, car1.DailyPrice, car1.Description);


            Console.WriteLine("------------------araba güncelleştiriliyor ve yazdırılıyor---------------------------");


            // Arabanın yeni değer giriliyor ve güncelleştiriliyor.
            
            car1.DailyPrice = 240.900;            
            carManager.Update(car1);
           
            Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                    car1.Id, car1.BrandId, car1.ColorId, car1.ModelYear, car1.DailyPrice, car1.Description);


            Console.WriteLine("----------------------Araba listeden silinip araba listesi tekrar yazdırılıyor------------------------------------");


            // Belirtilen araba List içinden siliniyor
            carManager.Delete(car1);
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                     car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);

            }


            Console.WriteLine("-------------------Yeni araba eklendikten sonra liste yazdırılıyor---------------------------------");


            // Yeni araba oluşturuluyor ve List içine ekleniyor ve arabalar tekrardan ekrana yazdırılıyor
            Car newCar = new Car();
            newCar.Id = 7;
            newCar.BrandId = 7;
            newCar.ColorId = 7;
            newCar.ModelYear = 2021;
            newCar.DailyPrice = 247.500;
            newCar.Description = "Peugeot Allure";
            carManager.Add(newCar);

            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                     car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);

            }
            Console.WriteLine("----------------------------------------------------------------------------------");


        }
    }
}
