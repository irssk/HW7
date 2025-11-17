using System.Linq;
using DoctorAppointment.Models;
using System.Collections.Generic;

namespace DoctorAppointment.Repositories
{
    public class DoctorRepository
    {
        private readonly List<Doctor> _doctors = new();
        private int _nextId = 1;

        public IEnumerable<Doctor> GetAll() => _doctors;

        public Doctor GetById(int id) =>
            _doctors.FirstOrDefault(d => d.Id == id);

        public Doctor Add(Doctor doctor)
        {
            doctor.Id = _nextId++;
            _doctors.Add(doctor);
            return doctor;
        }

        public bool Update(Doctor doctor)
        {
            var existing = GetById(doctor.Id);
            if (existing == null) return false;

            existing.FullName = doctor.FullName;
            existing.Specialty = doctor.Specialty;
            return true;
        }

        public bool Delete(int id)
        {
            var doctor = GetById(id);
            if (doctor == null) return false;

            _doctors.Remove(doctor);
            return true;
        }
    }
}
