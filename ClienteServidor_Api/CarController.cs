using ClienteServidor_Api.Data;
using ClienteServidor_Api.Models;
using ClienteServidor_Api.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;


namespace ClienteServidor_Api
{
    /*
     * Controller
     * herda de ControllerBase 
     * define o roteamento e possui os metodos HTTP
     * retorna tipos especificos e tambem ActionResults
     * 
     * rota defina pelo atributo:
     * [Route("api/cars")] e suas variações para cada verbo HTTP -> 
     * "api/cars" + /
     * 
     * utiliza da abstração ICarRepository que possui os metodos necessarios para interagir com nossa base dados
     * sem interagir diretamente com ela
     */
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository Repository;
        public CarController(ICarRepository repository) =>
            Repository = repository;

        /*
         * decorado com [HttpGet]
         * retorna um Ok -> 200 junto do resultado do metodo => um json com todos os Objs na nossa base de dados
         */
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

        /*
         * decorado com [HttpGet]
         * retorna um Ok -> 200 apenas com o Obj de respectivo Id
         * 
         * int id -> obtido atraves da rota: [FromRoute] -> "api/cars/1"
         * 
         */

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
        /*
         * decorado com [HttpPost]
         * retorna um Ok -> 201 created
         * 
         * EditorCarViewModel -> obtido do body da requisição [FromBody]
         * EditorCarViewModel -> view model mapeia e valida os dados fornecidos no body
         * 
         * inicializa um Car com os dados validados
         * 
         */
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

        /*
         * recebe [FromRoute] int id e [FromBody] EditorCarViewModel
         * 
         * realiza um GetById com o id obtido da rota e passa as novas informações a ele
         */
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
        /*
         * recebe [FromRoute] int id
         * 
         * retorna o Obj removido da base de dados
         */
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
