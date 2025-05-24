using ClienteServidor_Api.Data.Persistence;
using ClienteServidor_Api.Data.Persistence.JsonService;
using ClienteServidor_Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace ClienteServidor_Api.Data
{
    /*
     * Implementa a interface ICarRepository
     * 
     * tem como propiedade readonly Dictionary<int, Car> e readonly JsonWriter
     * para base de dados e escrita do json respectivamente
     * 
     * o Dictionary é obtido atraves do service JsonDataService atraves da injeção de dependencias
     * ja o JsonWriter é inicializado no construtor pois o mesmo nao armazena dados
     */
    public class CarRepository : ICarRepository
    {
        private readonly Dictionary<int, Car> _context;
        private readonly JsonWriter _writer;
        public CarRepository([FromServices] JsonDataService _data)
        {
            _context = _data._context;
            _writer = new JsonWriter();
        }

        /*
         * recebe um Car, caso o Id for = 0 gera um Id valido para o mesmo atraves do private GenerateId
         * aloca o Car na key correspondente ao seu Id
         * 
         * chama o metodo privado Save() para escrever o Obj em um json
         * retorna o Car adicionado
         */
        public Car Add(Car car)
        {
            if (car.Id == 0)
                car.Id = GenerateId(car);

            _context[car.Id] = car;
            Save();
            return car;
        }

        /*
         * Recebe um int => id
         * remove o Obj de respectiva key do Dictionary
         * 
         * chama o metodo privado Save() para remover o Obj em um json
         */
        public Car Delete(int id)
        {
            var removed = _context[id];
            _context.Remove(id);
            Save();
            return removed;
        }

        /*
         * Retorna todos os Objs do Dictionary
         */
        public IEnumerable<Car> GetAll()
        {
            return _context.Values;
        }

        /*
         * Recebe um int -> id e retorna o obj de respectiva key
         */
        public Car GetById(int id)
        {
            if (_context.ContainsKey(id))
                return _context[id];
            return null;
        }

        /*
         * Recebe um Car e chama o metodo Add() para alterar os valores
         */
        public Car Update(Car car)
        {
            return Add(car);
        }
        /*
         * Metodo privado que obtem um id valido a um obj
         * retorna um int -> key disponivel para o obj
         * se o Dictionary estiver vazio e primeira key é 1
         */
        private int GenerateId(Car car)
        {
            int key = _context.Count;
            while (_context.ContainsKey(key))
                key++;

            if (key != 0)
                return key;

            return 1;
        }
        /*
         * Metodo privado que apenas chama o metodo WriteCars do JsonWriter passando o _context -> Dictionary<int, car>
         * obitido atraves da injeção de dependencias garantindo que a mesma instancia seja usada por toda a aplicação
         */
        private void Save() =>
            _writer.WriteCars(_context);
    }
}
