using CarsAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public CarController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            var cars = _db.CarsList.ToList();
            return Ok(cars);
        }

        [HttpPost]
        public ActionResult<List<Car>> Post(Car carData)
        {
            _db.CarsList.Add(carData);
            _db.SaveChanges();

            return Ok(_db.CarsList.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<List<Car>> Patch(Car carData, int id)
        {
            var dataBaseCar = _db.CarsList.Find(id);

            if (dataBaseCar == null)
            {
                return BadRequest("Car not found");
            }

            dataBaseCar.Year = carData.Year;
            dataBaseCar.HorsePower = carData.HorsePower;
            dataBaseCar.Name = carData.Name;
            dataBaseCar.Color = carData.Color;
            dataBaseCar.Company = dataBaseCar.Company;

            _db.SaveChanges();

            return Ok(carData);
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            var carData = _db.CarsList.Find(id);
            
            if(carData == null)
            {
                return BadRequest("Car not found");
            }

            _db.CarsList.Remove(carData);
            _db.SaveChanges();

            return Ok(_db.CarsList.ToList());
        }
    }
}
