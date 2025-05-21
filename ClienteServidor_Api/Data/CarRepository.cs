using ClienteServidor_Api.Data.Persistence;
using ClienteServidor_Api.Models;


namespace ClienteServidor_Api.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly Dictionary<int, Car> _context;
        private readonly JsonWriter _writer;
        public CarRepository()
        {
            _context = new Dictionary<int, Car>();
            _writer = new JsonWriter();
        }


        public Car Add(Car car)
        {
            if (car.Id == 0)
                car.Id = GenerateId(car);

            _context[car.Id] = car;
            _writer.WriteCar(car);
            return car;
        }

        public void Delete(int id)
        {
            if (GetById(id) != null)
                _context.Remove(id);
            throw new Exception("O carro não existe em nosso sistema");
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
    }
}
