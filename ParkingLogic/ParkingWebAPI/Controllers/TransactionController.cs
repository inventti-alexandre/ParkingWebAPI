using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingWebAPI.Services;
using ParkingLogic;
using ParkingWebAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingWebAPI.Controllers
{
    [Produces("application/json")]
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

        [HttpGet("GetCurrentTransactions")]
        public List<Transaction> GetCurrentTransactions()
        {
            return service.GetCurrentTransactions();
        }

        [HttpGet("GetCurrentTransactions/{id}")]
        public IEnumerable<Transaction> GetCurrentTransactions(string id)
        {
            return service.GetCurrentTransactionsForCar(id);
        }

        [HttpPut("AddFunds/{id}")]
        public IActionResult Put(string id, [FromBody]AddFundsModel value)
        {
            Car carOfIssue;
            try
            {
                carOfIssue = service.AddFunds(value.Balance, id);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultModel()
                {
                    Success = false,
                    Message = ex.Message
                });
            }

            return Ok(carOfIssue);
        }
    }
}
