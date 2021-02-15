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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join cr in context.Cars
                             on r.CarId equals cr.Id
                             join c in context.Customers
                             on r.CustomerId equals c.UserId
                             join u in context.Users
                             on c.UserId equals u.Id
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarName = b.Name,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
