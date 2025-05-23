using ClienteServidor_Api.Models;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ClienteServidor_Api.Data.Persistence
{

    public class JsonWriter
    {
        private readonly string _path;
        public JsonWriter()
        {
            _path = "JsonBase/Car.json";
        }
        
        public void WriteCars(Dictionary<int, Car> cars)
        {
            if (File.Exists(_path))
                File.Delete(_path);
            using (FileStream fs = new FileStream(_path, FileMode.Append))
            using (Utf8JsonWriter _writer = new Utf8JsonWriter(fs, new JsonWriterOptions { Indented = true }))
            {
                _writer.WriteStartArray();
                
                foreach (var item in cars)
                {
                    _writer.WriteStartObject();
                    _writer.WriteNumber("id", item.Value.Id);
                    _writer.WriteString("model", item.Value.Model);
                    _writer.WriteNumber("mileage", item.Value.Mileage);
                    _writer.WriteNumber("price", item.Value.Price);
                    _writer.WriteNumber("year", item.Value.Year);
                    _writer.WriteString("description", item.Value.Description);
                    _writer.WriteEndObject();
                }

                _writer.WriteEndArray();
                _writer.Flush();

            }
        }
    }
}




