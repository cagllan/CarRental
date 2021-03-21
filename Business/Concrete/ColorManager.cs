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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        ICarService _carService;

        public ColorManager(IColorDal colorDal, ICarService carService)
        {
            _colorDal = colorDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {

            var result = BusinessRules.Run(ColorNameIsExists(color.Name));

            
            if (result != null)
            {
                return result;
            }

            _colorDal.Add(color);
           return new SuccessResult("Yeni Renk Eklendi");
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {

            var result = BusinessRules.Run(CheckColorId(color.Id), CheckColorIdToCarsTable(color.Id));

            
            if (result != null)
            {
                return result;
            }

            _colorDal.Delete(color);
            return new SuccessResult("Renk silindi");
        }

        public IDataResult<List<Color>> GetAll()
        {

            var result = BusinessRules.Run(ColorsAreExists());

            
            if (result != null)
            {
                return new ErrorDataResult<List<Color>>(result.Message);
            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),"Renkler listelendi");
            
        }

        public IDataResult<Color> GetById(int id)
        {

            var result = BusinessRules.Run(CheckColorId(id));

            
            if (result != null)
            {
                return new ErrorDataResult<Color>(result.Message);
            }

            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id), "Renk listelendi");
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(ColorNameIsExists(color.Name));

            if (result != null)
            {
                return result;
            }


            _colorDal.Update(color);
            return new SuccessResult("Renk güncellendi");
        }



        
        private IResult ColorNameIsExists(string name)
        {
            var result = _colorDal.Get(b => b.Name == name);
            if (result == null)
            {
                return new ErrorResult(Messages.BrandNameExists);
            }
            return new SuccessResult();
        }

        private IResult CheckColorId(int id)
        {
            var result = _colorDal.Get(b => b.Id == id);

            if (result == null)
            {
                return new ErrorResult("Bu kayıt bulunamadı.");
            }
            return new SuccessResult();
        }



        private IResult CheckColorIdToCarsTable(int id)
        {
            var result = _carService.GetCarsByColorId(id);

            if (result.Data.Count > 0)
            {
                return new ErrorResult("Bu rengi şu anda silemezsiniz");
            }

            return new SuccessResult();
        }



        private IResult ColorsAreExists()
        {
            var result = _colorDal.GetAll();

            if (result.Count <= 0)
            {
                return new ErrorResult("Herhangi bir renk kaydı yok");
            }
            return new SuccessResult();
        }
    }
}
