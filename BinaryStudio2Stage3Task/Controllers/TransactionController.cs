using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryForParkinLogic;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BinaryStudio2Stage3Task.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        Parking p = Parking.getParking();

        [HttpGet]
        public string GetLastTransactions()
        {
            return JsonConvert.SerializeObject(p.Transactions);
        }

        [Route("allTransaction"), HttpGet]
        public string AllTransaction(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public string UpTheBalance(int id, int value)
        {
            Car c = p.Cars.Find(x => x.Id == id);
            if (c == null)
                return JsonConvert.SerializeObject(p.Cars);
            c.changeBalance(value);
            return JsonConvert.SerializeObject(p.Cars);
        }
    }
}
