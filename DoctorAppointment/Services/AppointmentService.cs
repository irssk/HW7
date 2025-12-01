using DoctorAppointment.Models;
using DoctorAppointment.Repositories;
using DoctorAppointment.Storage;
using System;

namespace DoctorAppointment.Services
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _repo;

        public AppointmentService(IStorage storage)
        {
            _repo = new AppointmentRepository(storage);
        }

        public void ShowAll()
        {
            foreach (var a in _repo.GetAll())
                Console.WriteLine($"{a.Id}. Лікар #{a.DoctorId}, Пацієнт #{a.PatientId}, Дата: {a.Date}");
        }

        public void Add()
        {
            Console.Write("ID лікаря: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("ID пацієнта: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("Введіть дату (yyyy-mm-dd hh:mm): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            var appt = new Appointment
            {
                DoctorId = doctorId,
                PatientId = patientId,
                Date = date
            };

            _repo.Add(appt);
            Console.WriteLine("Запис додано!");
        }

        public void Update()
        {
            Console.Write("Введіть ID запису для оновлення: ");
            int id = int.Parse(Console.ReadLine());

            var existing = _repo.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Не знайдено!");
                return;
            }

            Console.Write("Новий ID лікаря: ");
            existing.DoctorId = int.Parse(Console.ReadLine());

            Console.Write("Новий ID пацієнта: ");
            existing.PatientId = int.Parse(Console.ReadLine());

            Console.Write("Нова дата: ");
            existing.Date = DateTime.Parse(Console.ReadLine());

            _repo.Update(existing);
            Console.WriteLine("Оновлено!");
        }

        public void Delete()
        {
            Console.Write("Введіть ID запису для видалення: ");
            int id = int.Parse(Console.ReadLine());

            if (_repo.Delete(id))
                Console.WriteLine("Видалено!");
            else
                Console.WriteLine("Не знайдено!");
        }
    }
}
