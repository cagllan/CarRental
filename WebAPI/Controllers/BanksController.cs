using Business.Abstract;
using Entities.Concrete;
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
    public class BanksController : ControllerBase
    {
        IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result = _bankService.Add(payment);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
