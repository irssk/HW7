using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DoctorAppointment.Storage
{
    public class JsonStorage : IStorage
    {
        public List<T> Load<T>(string fileName)
        {
            if (!File.Exists(fileName))
                return new List<T>();

            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public void Save<T>(string fileName, List<T> data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
    }
}
