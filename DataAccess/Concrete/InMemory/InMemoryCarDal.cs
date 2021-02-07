using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=141.950,Description="Renault Clio"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2013,DailyPrice=237.900,Description="BMW 3 Serisi"},
                new Car{Id=3,BrandId=2,ColorId=5,ModelYear=2020,DailyPrice=161.901,Description="Fiat Egea"},
                new Car{Id=4,BrandId=2,ColorId=3,ModelYear=1978,DailyPrice=29.500,Description="Mercedes - Benz "},
                new Car{Id=5,BrandId=3,ColorId=8,ModelYear=2000,DailyPrice=43.750,Description="Hyundai Elantra "},
                new Car{Id=6,BrandId=3,ColorId=7,ModelYear=2020,DailyPrice=512.500 ,Description="Volkswagen Passat "}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {           
            
           Car deleteCar =  _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {           

            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updatedCar = _cars.First(c => c.Id == car.Id);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.DailyPrice = car.DailyPrice;
        }
    }
}
