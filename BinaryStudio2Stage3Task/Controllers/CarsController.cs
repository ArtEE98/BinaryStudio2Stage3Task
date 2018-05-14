using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryForParkinLogic;
using Newtonsoft.Json;

namespace BinaryStudio2Stage3Task.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private Parking parking = Parking.getParking();
        // GET: api/values
        [HttpGet]
        public string GetAllCars()
        {
            parking.AddCar(new Car(1, CarType.Bus, 13));
            parking.AddCar(new Car(1, CarType.Bus, 13));
            parking.AddCar(new Car(2, CarType.Bus, 14));//just for testing

            var s = JsonConvert.SerializeObject(parking.Cars);
            return s;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {   
            Car result = parking.Cars.Find(x => x.Id == id);
            return JsonConvert.SerializeObject(result);
        }

        // POST api/values/5
        [HttpPost]
        public String Post([FromBody]Car car)
        {
            Boolean b = false;
            if (car == null)
                return "Can not add car";
            parking.AddCar(car);
            return JsonConvert.SerializeObject(parking.Cars);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            parking.DelCar(id);
            return JsonConvert.SerializeObject(parking.Cars);
        }
    }
}
