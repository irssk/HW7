using DoctorAppointment.Models;
using DoctorAppointment.Storage;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Repositories
{
    public class DoctorRepository
    {
        private readonly IStorage _storage;
        private readonly string _file = "doctors.data";
        private List<Doctor> _doctors;
        private int _nextId;

        public DoctorRepository(IStorage storage)
        {
            _storage = storage;
            _doctors = _storage.Load<Doctor>(_file);
            _nextId = _doctors.Count == 0 ? 1 : _doctors.Max(d => d.Id) + 1;
        }

        public IEnumerable<Doctor> GetAll() => _doctors;

        public Doctor Add(Doctor doctor)
        {
            doctor.Id = _nextId++;
            _doctors.Add(doctor);
            _storage.Save(_file, _doctors);
            return doctor;
        }

        public Doctor GetById(int id) =>
            _doctors.FirstOrDefault(x => x.Id == id);

        public bool Update(Doctor doctor)
        {
            var existing = GetById(doctor.Id);
            if (existing == null) return false;

            existing.FullName = doctor.FullName;
            existing.Specialty = doctor.Specialty;

            _storage.Save(_file, _doctors);
            return true;
        }

        public bool Delete(int id)
        {
            var doctor = GetById(id);
            if (doctor == null) return false;

            _doctors.Remove(doctor);
            _storage.Save(_file, _doctors);
            return true;
        }
    }
}
