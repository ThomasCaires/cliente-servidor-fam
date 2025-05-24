using ClienteServidor_Api.DTO;
using ClienteServidor_Api.Models;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace ClienteServidor_Api.Data.Persistence.JsonService
{
    /*
     * essa classe foi criada com o intuito de manter o tempo de vida do Dictionary<int, Car> por toda a aplicação atraves da 
     * injeção de dependencia.
     * tambem é responsavel por iniciar o _context com os dados do Json caso a aplicação seja finalizada 
     */
    public class JsonDataService
    {
        public Dictionary<int, Car> _context;
        public string jsonFilePath = "JsonBase/Car.json";

        public JsonDataService()
        {
            _context = new Dictionary<int, Car>();
            //var jsonFilePath = ("JsonBase/Car.json");

            if (File.Exists(jsonFilePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(jsonFilePath);

                    /*
                     * List e array se mostraram menos problematicas ao Deserialize
                     * por isso é passado um DTO que mapeia os dados para serem devidamente 
                     * desserializados em um Obj c# e depois passado ao Dictionary<int, Car> _context
                     * garantindo que seu id seja a key no _context
                     */
                    List<JsonCarDTO> cars = JsonSerializer.Deserialize<List<JsonCarDTO>>(jsonString);

                    
                    foreach (var model in cars)
                    {
                        /*
                         * adiciona no _context o Id como key e depois cria o Car com os dados agora devidamente na classe base
                         */
                        _context.Add(model.Id, new Car
                        {
                            Id = model.Id,
                            Model = model.Model,
                            Mileage = model.Mileage,
                            Price = model.Price,
                            Year = model.Year,
                            Description = model.Description,

                        });
                    }

                }
                /*
                 * resolve um erro comum que percebemos durante os testes, onde caso o Json estivese VAZIO ou
                 * de alguma forma identado de maneira errada onde um JsonException era lançado, tentamos resolver atraves 
                 * de Utf8StreamReader para corrigir os erros provenientes de um json corrompido, porem criou-se uma 
                 * complexidade desnecessaria, ja que todo json lido pela aplicação devera ser criado pela mesma e por isso
                 * decidimos retornar um Dictionary<int, Car> vazio oque resolve a Exception lançada ao iniciar a
                 * aplicação com um Car.json vazio
                 */
                catch
                {
                    _context = new Dictionary<int, Car>();
                }

            }
            //caso o arquivo nao exista sera criado um Dictionary vazio
            else
                _context = new Dictionary<int, Car>();

        }
    }
}
