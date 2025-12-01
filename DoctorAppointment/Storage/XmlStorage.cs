using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DoctorAppointment.Storage
{
    public class XmlStorage : IStorage
    {
        public List<T> Load<T>(string fileName)
        {
            if (!File.Exists(fileName))
                return new List<T>();

            XmlSerializer serializer = new(typeof(List<T>));

            using FileStream fs = new(fileName, FileMode.Open);
            return (List<T>)serializer.Deserialize(fs);
        }

        public void Save<T>(string fileName, List<T> data)
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using FileStream fs = new(fileName, FileMode.Create);
            serializer.Serialize(fs, data);
        }
    }
}
