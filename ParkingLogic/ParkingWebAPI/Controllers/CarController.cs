using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingWebAPI.Services;
using System.Net.Http;
using ParkingWebAPI.Models;
using Newtonsoft.Json;
using System.Net;
using ParkingLogic;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarController : Controller
    {

        private ParkingService service {get; set; }

        public CarController(ParkingService service)
        {
            this.service = service;
        }

        // GET: api/values
        [HttpGet]
        public List<Car> Get()
        {
            return service.GetAllCars();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Car Get(string id)
        {
            return service.GetCarById(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CarFormDataModel body)
        {
            Car newCar;
            try
            {
                newCar = service.AddCar(body.Balance, body.Type);
            }catch (Exception ex)
            {
                return BadRequest(new ResultModel
                {
                    Success = false,
                    Message = ex.Message
                }); ;
            }

            return Ok(newCar);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                service.RemoveCar(id);
            }
            catch
            {
                return Ok(new ResultModel
                {
                    Success = false,
                    Message = "Balance for this car is negative. Please, pay the fee"
                });
            }
            return Ok(new ResultModel
            {
                Success = true,
                Message = "The car was successfully removed from parking"
            });
        }
    }
}
