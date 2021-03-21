using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntifyFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cr in context.Cars
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             join c in context.Colors
                             on cr.ColorId equals c.Id                             
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 BrandName = b.Name,
                                 Name = cr.Description,
                                 ColorName = c.Name,
                                 DailyPrice = cr.DailyPrice,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 CarImages = (from i in context.CarImages where i.CarId == cr.Id select i).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

      

        public CarDetailDto GetCarDetailsByCarId(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cr in context.Cars
                             join c in context.Colors on cr.ColorId equals c.Id
                             join b in context.Brands on cr.BrandId equals b.Id
                             where cr.Id == id
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 BrandName = b.Name,
                                 Name = cr.Description,
                                 ColorName = c.Name,
                                 DailyPrice = cr.DailyPrice,
                                 CarImages = (from i in context.CarImages where i.CarId == cr.Id select i).ToList()
                             };

                return result.First();
            }
        }
    }
}
