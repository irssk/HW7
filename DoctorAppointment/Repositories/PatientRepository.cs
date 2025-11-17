using System.Linq;
using DoctorAppointment.Models;
using System.Collections.Generic;

namespace DoctorAppointment.Repositories
{
    public class PatientRepository
    {
        private readonly List<Patient> _patients = new();
        private int _nextId = 1;

        public IEnumerable<Patient> GetAll() => _patients;

        public Patient GetById(int id) =>
            _patients.FirstOrDefault(p => p.Id == id);

        public Patient Add(Patient patient)
        {
            patient.Id = _nextId++;
            _patients.Add(patient);
            return patient;
        }

        public bool Update(Patient patient)
        {
            var existing = GetById(patient.Id);
            if (existing == null) return false;

            existing.FullName = patient.FullName;
            existing.Age = patient.Age;
            return true;
        }

        public bool Delete(int id)
        {
            var patient = GetById(id);
            if (patient == null) return false;

            _patients.Remove(patient);
            return true;
        }
    }
}
