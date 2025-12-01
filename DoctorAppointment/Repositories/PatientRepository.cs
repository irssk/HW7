using DoctorAppointment.Models;
using DoctorAppointment.Storage;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Repositories
{
    public class PatientRepository
    {
        private readonly IStorage _storage;
        private readonly string _file = "patients.data";
        private List<Patient> _patients;
        private int _nextId;

        public PatientRepository(IStorage storage)
        {
            _storage = storage;

            _patients = _storage.Load<Patient>(_file);
            _nextId = _patients.Count == 0 ? 1 : _patients.Max(p => p.Id) + 1;
        }

        public IEnumerable<Patient> GetAll() => _patients;

        public Patient GetById(int id) =>
            _patients.FirstOrDefault(p => p.Id == id);

        public Patient Add(Patient patient)
        {
            patient.Id = _nextId++;
            _patients.Add(patient);
            _storage.Save(_file, _patients);
            return patient;
        }

        public bool Update(Patient patient)
        {
            var existing = GetById(patient.Id);
            if (existing == null) return false;

            existing.FullName = patient.FullName;
            existing.Age = patient.Age;

            _storage.Save(_file, _patients);
            return true;
        }

        public bool Delete(int id)
        {
            var patient = GetById(id);
            if (patient == null) return false;

            _patients.Remove(patient);
            _storage.Save(_file, _patients);
            return true;
        }
    }
}
