using System.Collections.Generic;

namespace DoctorAppointment.Storage
{
    public interface IStorage
    {
        List<T> Load<T>(string fileName);
        void Save<T>(string fileName, List<T> data);
    }
}
