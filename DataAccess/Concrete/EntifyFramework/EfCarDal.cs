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
        public List<CarDetailDto> GetCarDetails()
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
                                 DailyPrice = cr.DailyPrice                                 
                             };

                return result.ToList();
            }
        }
    }
}
