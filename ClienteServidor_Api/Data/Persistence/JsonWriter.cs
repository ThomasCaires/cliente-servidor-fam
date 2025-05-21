using ClienteServidor_Api.Models;
using System.Text.Json;


namespace ClienteServidor_Api.Data.Persistence
{

    public class JsonWriter
    {
        //private Utf8JsonWriter _writer = new Utf8JsonWriter(new FileStream("/JsonBase", FileMode.Create), new JsonWriterOptions { Indented = true });

        public JsonWriter()
        {
        }

        public void WriteCar(Car car)
        {
            //var item_serialized = JsonSerializer.Serialize(car);
            using(FileStream fs = new FileStream("JsonBase/Car.json", FileMode.Append))
            using(Utf8JsonWriter _writer = new Utf8JsonWriter(fs,new JsonWriterOptions { Indented = true }))
            {
                _writer.WriteStartArray();
                //_writer.WriteStartObject();
                JsonSerializer.Serialize<Car>(_writer,car);
                //_writer.WriteEndObject();
                _writer.Flush();
               
            }

        }
    }
}



