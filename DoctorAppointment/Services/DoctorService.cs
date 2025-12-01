using DoctorAppointment.Models;
using DoctorAppointment.Repositories;
using DoctorAppointment.Storage;
using System;

namespace DoctorAppointment.Services
{
    public class DoctorService
    {
        private readonly DoctorRepository _repo;

        public DoctorService(IStorage storage)
        {
            _repo = new DoctorRepository(storage);
        }

        public void ShowAll()
        {
            foreach (var d in _repo.GetAll())
                Console.WriteLine($"{d.Id}. {d.FullName} — {d.Specialty}");
        }

        public void Add()
        {
            Console.Write("Введіть ім'я лікаря: ");
            string name = Console.ReadLine();

            Console.Write("Введіть спеціальність: ");
            string spec = Console.ReadLine();

            var doctor = new Doctor { FullName = name, Specialty = spec };
            _repo.Add(doctor);

            Console.WriteLine("Лікаря додано!");
        }

        public void Update()
        {
            Console.Write("Введіть ID лікаря для оновлення: ");
            int id = int.Parse(Console.ReadLine());

            var existing = _repo.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Не знайдено!");
                return;
            }

            Console.Write("Нове ім'я: ");
            existing.FullName = Console.ReadLine();

            Console.Write("Нова спеціальність: ");
            existing.Specialty = Console.ReadLine();

            _repo.Update(existing);
            Console.WriteLine("Оновлено!");
        }

        public void Delete()
        {
            Console.Write("Введіть ID лікаря для видалення: ");
            int id = int.Parse(Console.ReadLine());

            if (_repo.Delete(id))
                Console.WriteLine("Видалено!");
            else
                Console.WriteLine("Не знайдено!");
        }
    }
}
