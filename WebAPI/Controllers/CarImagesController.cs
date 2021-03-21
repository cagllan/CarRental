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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnviroment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnviroment)
        {
            _carImageService = carImageService;
            _webHostEnviroment = webHostEnviroment;
           


        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetImagesByCarId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add([FromForm(Name ="image")] IFormFile image, [FromForm] CarImage carImage)
        {
                       
             var result = _carImageService.Add(image, carImage);

            if (result.Success)
            {
                

                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = "image")] IFormFile image,[FromForm] CarImage carImage)
        {
            

            var result = _carImageService.Update(image, carImage);

            if (result.Success)
            {
                
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            
            var result = _carImageService.Delete(carImage);
            
            if (result.Success)
            {
                
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
