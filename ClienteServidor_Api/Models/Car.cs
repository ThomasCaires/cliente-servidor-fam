
namespace ClienteServidor_Api.Models
{
    /*
     * classe model usada como base
     */
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public long Mileage { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
