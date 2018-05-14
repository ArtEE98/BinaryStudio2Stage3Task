using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryForParkinLogic;

namespace BinaryStudio2Stage3Task.Controllers
{
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {
        private Parking p = Parking.getParking();

        // GET api/values
        [Route("freePlace"), HttpGet]
        public string GetFreePlace()
        {
            return p.FreeSize().ToString();
        }

        [Route("takenSeat"), HttpGet]
        public string Get()
        {
            return (p.Cars.Count).ToString();
        }

        [Route("income"), HttpGet]
        public string Post()
        {
            return p.Income().ToString();
        }

       
    }
}
