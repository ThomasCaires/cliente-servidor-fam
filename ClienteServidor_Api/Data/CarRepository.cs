using ClienteServidor_Api.Data.Persistence;
using ClienteServidor_Api.Data.Persistence.JsonService;
using ClienteServidor_Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace ClienteServidor_Api.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly Dictionary<int, Car> _context;
        private readonly JsonWriter _writer;
        public CarRepository([FromServices] JsonDataService _data)
        {
            _context = _data._context;
            if (_context == null)
                throw new Exception("O Json esta vazio!! o mesmo deve ser deletado para que o sistama crie um novo");
            _writer = new JsonWriter();
        }


        public Car Add(Car car)
        {
            if (car.Id == 0)
                car.Id = GenerateId(car);

            _context[car.Id] = car;
            Save();
            return car;
        }

        public Car Delete(int id)
        {
            var removed = _context[id];
            _context.Remove(id);
            Save();
            return removed;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Values;
        }

        public Car GetById(int id)
        {
            if (_context.ContainsKey(id))
                return _context[id];
            return null;
        }

        public Car Update(Car car)
        {
            return Add(car);
        }

        private int GenerateId(Car car)
        {
            int key = _context.Count;
            while (_context.ContainsKey(key))
                key++;

            if (key != 0)
                return key;

            return 1;
        }
        private void Save() =>
            _writer.WriteCars(_context);
    }
}
