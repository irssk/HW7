using DoctorAppointment.Models;
using DoctorAppointment.Storage;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Repositories
{
    public class AppointmentRepository
    {
        private readonly IStorage _storage;
        private readonly string _file = "appointments.data";
        private List<Appointment> _appointments;
        private int _nextId;

        public AppointmentRepository(IStorage storage)
        {
            _storage = storage;

            _appointments = _storage.Load<Appointment>(_file);
            _nextId = _appointments.Count == 0 ? 1 : _appointments.Max(a => a.Id) + 1;
        }

        public IEnumerable<Appointment> GetAll() => _appointments;

        public Appointment GetById(int id) =>
            _appointments.FirstOrDefault(a => a.Id == id);

        public Appointment Add(Appointment appt)
        {
            appt.Id = _nextId++;
            _appointments.Add(appt);
            _storage.Save(_file, _appointments);
            return appt;
        }

        public bool Update(Appointment appt)
        {
            var existing = GetById(appt.Id);
            if (existing == null) return false;

            existing.DoctorId = appt.DoctorId;
            existing.PatientId = appt.PatientId;
            existing.Date = appt.Date;

            _storage.Save(_file, _appointments);
            return true;
        }

        public bool Delete(int id)
        {
            var appt = GetById(id);
            if (appt == null) return false;

            _appointments.Remove(appt);
            _storage.Save(_file, _appointments);
            return true;
        }
    }
}
