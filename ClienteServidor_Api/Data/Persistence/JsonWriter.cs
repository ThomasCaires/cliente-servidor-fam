using ClienteServidor_Api.Models;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ClienteServidor_Api.Data.Persistence
{
    /*
     * Classe responsavel por escrever no json
     */
    public class JsonWriter
    {
        private readonly string _path;
        public JsonWriter()
        {
            _path = "JsonBase/Car.json";
        }

        /*
         * Recebe um Dictionary<int, Car> cars
         * testa se o arquivo existe no path e caso existir deleta o mesmo
         * (o service JsonDataService garante que o dictionary chegue nesse ponto da aplicação devidamente carregado com os dados)
         * isso acontece para manter os dados dentro de um jsonArray
         * FileMode.Append -> escreve o Obj no final do arquivo
         * { Indented = true } -> garante a identação do json
         * 
         * por se tratar de um Dictionary definimos os valores explicitamente
         * ex:
         * 
         *      _writer.WriteString("model", item.Value.Model);
         * 
         * 
         */
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




