using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;


        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(CarImage carImage)
        {
            var results = BusinessRules.Run(CheckImageCountLimit(carImage.CarId));
            if (results != null)
            {
                return results;
            }
            var addedCarImage = CreatedFile(carImage).Data;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IResult Update(CarImage carImage)
        {
            
            _carImageDal.Update(carImage);
            return new SuccessResult("Image updated");
        }

        private IResult CheckImageCountLimit(int CarId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == CarId);
            if (result.Count >= 5)
            {
                return new ErrorResult("En fazla 5 resim ekleyebilirsiniz.");

            }
            return new SuccessResult();

        }


        private IDataResult<CarImage> CreatedFile(CarImage carImage)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Image");
            var uniqueFilename = Guid.NewGuid().ToString("N")
                + "CAR-" + carImage.CarId + "-" + DateTime.Now.ToShortDateString();

            string source = Path.Combine(carImage.ImagePath);

            string result = $@"{path}\{uniqueFilename}";

            try
            {

                File.Move(source, path + @"\" + uniqueFilename);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<CarImage>(exception.Message);
            }

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now }, "resim eklendi");
     
        }
    }
 }
