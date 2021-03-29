using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckTheRentedCarBeenReturned(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
            
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }





        public IDataResult<List<Rental>> GetByCarId(int id)
        {
            throw new NotImplementedException();
        }




        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.RentalView);
        }

       

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.RentalsListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

       
        private IDataResult<Rental> CheckCarIsExists(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);            

            if(result.Count < 1)
            {                
                return new ErrorDataResult<Rental>();
            }

            var lastItem = result[result.Count - 1];
            return new SuccessDataResult<Rental>(lastItem);
        }

        
        private IResult CheckTheRentedCarBeenReturned(Rental rental)
        {
            var result = CheckCarIsExists(rental.CarId);

            if (result.Data == null || result.Data.ReturnDate != null)
            {
                
                return new SuccessResult();
            }
            return new ErrorResult("Bu araba henüz teslim edilmemiş.");
        }

       
    }
}
