using System.Linq;
using DoctorAppointment.Models;
using System.Collections.Generic;

namespace DoctorAppointment.Repositories
{
    public class AppointmentRepository
    {
        private readonly List<Appointment> _appointments = new();
        private int _nextId = 1;

        public IEnumerable<Appointment> GetAll() => _appointments;

        public Appointment GetById(int id) =>
            _appointments.FirstOrDefault(a => a.Id == id);

        public Appointment Add(Appointment appt)
        {
            appt.Id = _nextId++;
            _appointments.Add(appt);
            return appt;
        }

        public bool Update(Appointment appt)
        {
            var existing = GetById(appt.Id);
            if (existing == null) return false;

            existing.DoctorId = appt.DoctorId;
            existing.PatientId = appt.PatientId;
            existing.Date = appt.Date;

            return true;
        }

        public bool Delete(int id)
        {
            var appt = GetById(id);
            if (appt == null) return false;

            _appointments.Remove(appt);
            return true;
        }
    }
}
