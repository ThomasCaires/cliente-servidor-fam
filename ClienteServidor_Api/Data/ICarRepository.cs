using ClienteServidor_Api.Models;


namespace ClienteServidor_Api.Data
{
    /*
     * Repositorio definindo os metodos que devem ser implementados para interagir com
     * o banco de dados (não estamos usando um)
     * Get by Id -> retorna o Item de mesmo Id
     * GetAll -> retornaria todos os itens do context porem como existe apenas uma 
     * entidade e estamos utilizando uma Collection no lugar de um DB, retornara todo o context
     * Add -> apenas adiciona o Obj ao context, a criação do mesmo é responsabilidade do Controller
     * Update -> modifica um item ja existente
     * Delete -> apaga o item do context
     */
    public interface ICarRepository
    {
        public Car GetById(int id);
        public IEnumerable<Car> GetAll();
        public Car Add(Car car);
        public Car Update(Car car);
        public Car Delete(int id);
    }
}
