using ClienteServidor_Api.Models;


namespace ClienteServidor_Api.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly Dictionary<int, Car> _context;
        public CarRepository() =>
            _context = new Dictionary<int, Car>();

        public Car Add(Car car)
        {
            if(car.Id == 0) 
                GenerateId(car);
            return _context[car.Id] = car;
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
            return _context[id];
        }

        public Car Update(Car car)
        {
            return Add(car);
        }

        private void GenerateId(Car car)
        {
            int key = _context.Count;
            while (_context.ContainsKey(key))
                key++;
            car.Id = key;
        }
    }
}
