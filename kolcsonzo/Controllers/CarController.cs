using kolcsonzo.Models;
using kolcsonzo.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolcsonzo.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Car> Post(CreateCarDto createCarDto)
        {
            using (var context = new KolcsonzoContext())
            {
                var Car = new Car()
                {
                    Id = Guid.NewGuid().ToString(),
                     Marka= createCarDto.Marka,
                    Model = createCarDto.Model,
                    Evjarat = createCarDto.Evjarat
                };
                if (createCarDto.Marka != null)
                {
                    
                        context.Add(Car);
                        context.SaveChanges();
                        return StatusCode(201, Car);

                    
                }
                return BadRequest();
            }


        }
        [HttpGet]
        public ActionResult<Car> GetAll()
        {
            using (var context = new KolcsonzoContext())
            {
                return Ok(context.Cars.ToList());
            }
        }

        [HttpGet]
        public ActionResult<Car> GetById(string id)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var Car = ctx.Cars.FirstOrDefault(x => x.Id == id);
                if (Car != null)
                {
                    return Ok(Car);
                }
                return NotFound();
            }
        }

        [HttpPut]

        public ActionResult<Car> Put(string id, UpdateCarDto updateCarDto)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var existingCar = ctx.Cars.FirstOrDefault(x => x.Id == id);
                if (existingCar != null)
                {
                    ctx.SaveChanges();
                    return Ok("Car Data frissitve");
                }
                return NotFound();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param >asdsadsadsadsadasadsa</param>
        /// <returns></returns>

        [HttpDelete]
        public ActionResult<Car> Delete(string id)
        {
            using (var ctx = new KolcsonzoContext())
            {
                var delCusotmer = ctx.Cars.FirstOrDefault(y => y.Id == id);
                if (delCusotmer != null)
                {
                    ctx.Remove(delCusotmer);
                    ctx.SaveChanges();
                    return Ok("Car torole fn");
                }
                return NotFound();
            }
        }
    }
}
