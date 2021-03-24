using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Helper;
using DataAccess.Concrete.EntifyFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        IWebHostEnvironment _webHostEnviroment;

        public CarsController(ICarService carService, IWebHostEnvironment webHostEnviroment)
        {
            _carService = carService;
            _webHostEnviroment = webHostEnviroment;
        }

        [HttpGet("getall")]
        
        public IActionResult GetAll()
        {

            var result = _carService.GetAll();

            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {

           
            var result = _carService.GetCarDetails();

            foreach (var item in result.Data)
            {
                if (item.CarImages.Count <= 0)
                {
                    item.CarImages.Add(new CarImage() {CarId=item.CarId,ImagePath=ImageUploadHelper.DefaultImagePath() });
                    
                }
            }
            

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {


            var result = _carService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }


        [HttpGet("getcardetailbycarid")]
        public IActionResult GetCarDetailByCarId(int id)
        {
            
            var result = _carService.GetCarDetailByCarId(id);

            if (result.Data.CarImages.Count <= 0)
            {
                result.Data.CarImages.Add(new CarImage() { CarId = result.Data.CarId, ImagePath = ImageUploadHelper.DefaultImagePath() });
            }

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getbybrandid")]
        public IActionResult ByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getcardetailsbybrandid")]
        public IActionResult GetCarsDetailByBrandId(int id)
        {


            var result = _carService.GetCarsDetailsByBrandId(id);

            foreach (var item in result.Data)
            {
                if (item.CarImages.Count <= 0)
                {
                    item.CarImages.Add(new CarImage() { CarId = item.CarId, ImagePath = ImageUploadHelper.DefaultImagePath() });

                }
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycolorıd")]
        public IActionResult ByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getcardetailsbycolorid")]
        public IActionResult GetCarsDetailByColorId(int id)
        {
            var result = _carService.GetCarsDetailsByColorId(id);

            foreach (var item in result.Data)
            {
                if (item.CarImages.Count <= 0)
                {
                    item.CarImages.Add(new CarImage() { CarId = item.CarId, ImagePath = ImageUploadHelper.DefaultImagePath() });

                }
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getcardetailsbybrandandcolorid")]
        public IActionResult GetCarDetailsByBrandAndColorid(int brandId,int colorId)
        {
            var result = _carService.GetCarDetailsByBrandAndColorid(brandId, colorId);

            foreach (var item in result.Data)
            {
                if (item.CarImages.Count <= 0)
                {
                    item.CarImages.Add(new CarImage() { CarId = item.CarId, ImagePath = ImageUploadHelper.DefaultImagePath() });

                }
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        

    }
}
