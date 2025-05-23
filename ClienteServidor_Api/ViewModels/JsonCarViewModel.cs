using System.Text.Json.Serialization;

namespace ClienteServidor_Api.ViewModels
{
    public class JsonCarViewModel
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
