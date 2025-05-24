using System.Text.Json.Serialization;

namespace ClienteServidor_Api.DTO
{
    /*
     * DTO mapeando um Obj c# para um json
     */
    public class JsonCarDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("model")]
        public string? Model { get; set; }
        [JsonPropertyName("mileage")]
        public long Mileage { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
