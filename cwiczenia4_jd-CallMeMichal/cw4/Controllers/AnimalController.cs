using cw4.Models;
using cw4.Service;
using Microsoft.AspNetCore.Mvc;

namespace cw4.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalDbService _animalDbService;
  

        public AnimalController(IAnimalDbService animalDbService)
        {
            _animalDbService = animalDbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimal([FromQuery] string orderBy)
        {

            IList<Animal> animals = await _animalDbService.GetAnimalListAsync(orderBy);
            if(animals == null)
            {
                Response.StatusCode = 204;
            }
            return Ok(animals);
        }
        [HttpPost]
        public async Task<IActionResult> AddAnimal(Animal animal) 
        {

            var result = await _animalDbService.AddAnimalAsync(animal);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("idAnimal")]
        public async Task<IActionResult> PutAnimal(int id, [FromBody]Animal animal) 
        {
            var result = await _animalDbService.PutAnimalAsync(id,animal);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("idAnimal")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {

           var result = await _animalDbService.DeleteAnimalAsync(id);
           
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
           
        }
    }
}
