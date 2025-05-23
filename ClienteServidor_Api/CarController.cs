using ClienteServidor_Api.Data;
using ClienteServidor_Api.Models;
using ClienteServidor_Api.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;


namespace ClienteServidor_Api
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository Repository;
        public CarController(ICarRepository repository) =>
            Repository = repository;

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(Repository.GetAll());
            }
            catch
            {
                return BadRequest("01XE1 - Base de dados não encontrada");
            }


        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(Repository.GetById(id));
            }
            catch
            {
                return BadRequest($"O {id} não existe!! informe um id valido");
            }

        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] EditorCarViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var car = new Car
            {
                Id = 0,
                Model = model.Model,
                Mileage = model.Mileage,
                Price = model.Price,
                Year = model.Year,
                Description = model.Description,
            };
            Repository.Add(car);
            return Created();

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,
            [FromBody] EditorCarViewModel model)
        {
            var car = Repository.GetById(id);
            if (car == null)
                return NotFound("Id não encontrado");

            car.Price = model.Price;
            car.Description = model.Description;
            car.Year = model.Year;
            car.Model = model.Model;
            car.Mileage = model.Mileage;

            return Ok(Repository.Update(car));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                return Ok(Repository.Delete(id));
            }
            catch
            {
                return StatusCode(500, "Nao foi possivel remover o veiculo");
            }
        }
    }
}
