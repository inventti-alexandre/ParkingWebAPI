using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingWebAPI.Services;
using ParkingLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private ParkingService service { get; set; }

        public TransactionController(ParkingService service)
        {
            this.service = service;
        }

        [HttpGet("ShowTransactionLog")]
        public List<SerializeTransactions> ShowTransactionLog()
        {
            return service.ShowTransactionLog();
        }
    }
}
