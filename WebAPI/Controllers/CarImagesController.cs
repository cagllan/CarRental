using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        IWebHostEnvironment _webHostEnviroment;
        ICarImageService _carImageService;

        public CarImagesController(IWebHostEnvironment webHostEnviroment, ICarImageService carImageService)
        {
            _webHostEnviroment = webHostEnviroment;
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] FileUpload objectFile,[FromForm] CarImage carImage)
        {
            string path = _webHostEnviroment.WebRootPath + "\\uploads\\";
            var newPath = Guid.NewGuid().ToString() + Path.GetExtension(objectFile.files.FileName);


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newPath))
            {
                objectFile.files.CopyTo(fileStream);
                fileStream.Flush();
            }
            if (objectFile == null)
            {
                carImage.ImagePath = path + "default.png";
            }
            var result = _carImageService.Add(new CarImage
            {
                CarId = carImage.CarId,
                Date = DateTime.Now,
                ImagePath = newPath
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }


        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getImagesByCarId")]
        public IActionResult GetAllImagesByCarId(int Id)
        {
            
            var result = _carImageService.GetImagesByCarId(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getImagesById")]
        public IActionResult GetAllImagesById(int Id)
        {
            var result = _carImageService.GetById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
