using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        ICarService _carService;

        public BrandManager(IBrandDal brandDal,ICarService carService)
        {
            _brandDal = brandDal;
            _carService = carService;
        }



        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            var result = BusinessRules.Run(BrandNameIsExists(brand.Name));

            
            if(result != null)
            {
                return result;
            }

            _brandDal.Add(brand);
            return new SuccessResult("Yeni Model Eklendi");
            
        }



        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {

            var result = BusinessRules.Run(CheckBrandId(brand.Id), CheckBrandIdToCarsTable(brand.Id));

            
            if (result != null)
            {
                return result;
            }

            
            _brandDal.Delete(brand);
            return new SuccessResult("Model silindi.");
        }




        public IDataResult<List<Brand>> GetAll()
        {
            var result = BusinessRules.Run(BrandsAreExists());

            
            if (result != null)
            {
                return new ErrorDataResult<List<Brand>>(result.Message);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), "Modeller listelendi");
        }




        public IDataResult<Brand> GetById(int id)
        {
            var result = BusinessRules.Run(CheckBrandId(id));

            
            if (result != null)
            {
                return new ErrorDataResult<Brand>(result.Message);
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id), "Model listelendi");
        }





        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(BrandNameIsExists(brand.Name));

            if (result != null)
            {
                return result;
            }

            _brandDal.Update(brand);
            return new SuccessResult("Model güncellendi.");
        }






       
        private IResult BrandNameIsExists(string name)
        {
            var result = _brandDal.Get(b => b.Name == name);

            if (result != null)
            {
                return new ErrorResult(Messages.BrandNameExists);
            }
            return new SuccessResult();
        }

        private IResult CheckBrandId(int id)
        {
            var result = _brandDal.Get(b => b.Id == id);

            if (result == null)
            {
                return new ErrorResult("Bu kayıt bulunamadı.");
            }
            return new SuccessResult();
        }

        

        private IResult CheckBrandIdToCarsTable(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if(result.Data.Count > 0)
            {
                return new ErrorResult("Bu modeli şu anda silemezsiniz"); 
            }

            return new SuccessResult();
        }



        private IResult BrandsAreExists()
        {
            var result = _brandDal.GetAll();

            if (result.Count <= 0 )
            {
                return new ErrorResult("Herhangi bir model kaydı yok");
            }
            return new SuccessResult();
        }


    }
}
