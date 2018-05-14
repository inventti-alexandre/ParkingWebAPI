using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {
        private ParkingService service { get; set; }

        public ParkingController(ParkingService service)
        {
            this.service = service;
        }

        [HttpGet("GetAvailablePlaces")]
        public int GetAvailablePlaces()
        {
            return service.GetAvailablePlaces();
        }

        [HttpGet("GetOccupiedPlaces")]
        public int GetOccupiedPlaces()
        {
            return service.GetOccupiedPlaces();
        }

        [HttpGet("GetRevenue")]
        public double GetRevenue()
        {
            return service.GetParkingRevenue();
        }


    }
}
