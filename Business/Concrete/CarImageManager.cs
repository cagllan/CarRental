using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile image, CarImage carImage)
        {

            var result = BusinessRules.Run(MaximumImageLimit(carImage.CarId), ImageExtension(image.FileName));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = ImageUploadHelper.AddImage(image);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult("Yeni Resim Eklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            
            ImageUploadHelper.DeleteImage(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Resim silindi.");
        }



        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), "Resimler listelendi");
        }



        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id), "Resim listelendi");
        }



        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == id), "Resimler listelendi");
        }



        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile image, CarImage carImage)
        {
            var oldImagePath = _carImageDal.Get(i => i.Id == carImage.Id).ImagePath;


            var result = BusinessRules.Run(MaximumImageLimit(carImage.CarId), ImageExtension(image.FileName));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = ImageUploadHelper.UpdateImage(image, oldImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);            

            return new SuccessResult("Resim güncellendi.");
        }

        private IResult MaximumImageLimit(int carId)
        {
           var result =  _carImageDal.GetAll(i=>i.CarId == carId);

           
            if (result.Count >= 5)
            {
                return new ErrorResult("En fazla 5 resim ekleyebilirsiniz.");
            }

            return new SuccessResult();
        }

        private IResult ImageExtension(string arg)
        {
            var imageExtension = Path.GetExtension(arg);

            List<string> extensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };

            foreach (var extension in extensions)
            {
                if (imageExtension == extension)
                {
                    return new SuccessResult();
                }

            }

            return new ErrorResult("Resim formatı uygun değil");
        }


    }
}
