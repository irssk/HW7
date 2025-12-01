using DoctorAppointment.Models;
using DoctorAppointment.Repositories;
using DoctorAppointment.Storage;
using System;

namespace DoctorAppointment.Services
{
    public class PatientService
    {
        private readonly PatientRepository _repo;

        public PatientService(IStorage storage)
        {
            _repo = new PatientRepository(storage);
        }

        public void ShowAll()
        {
            foreach (var p in _repo.GetAll())
                Console.WriteLine($"{p.Id}. {p.FullName} (Вік: {p.Age})");
        }

        public void Add()
        {
            Console.Write("Введіть ім'я пацієнта: ");
            string name = Console.ReadLine();

            Console.Write("Введіть вік: ");
            int age = int.Parse(Console.ReadLine());

            var patient = new Patient { FullName = name, Age = age };
            _repo.Add(patient);

            Console.WriteLine("Пацієнта додано!");
        }

        public void Update()
        {
            Console.Write("Введіть ID пацієнта для оновлення: ");
            int id = int.Parse(Console.ReadLine());

            var existing = _repo.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Не знайдено!");
                return;
            }

            Console.Write("Нове ім'я: ");
            existing.FullName = Console.ReadLine();

            Console.Write("Новий вік: ");
            existing.Age = int.Parse(Console.ReadLine());

            _repo.Update(existing);
            Console.WriteLine("Оновлено!");
        }

        public void Delete()
        {
            Console.Write("Введіть ID пацієнта для видалення: ");
            int id = int.Parse(Console.ReadLine());

            if (_repo.Delete(id))
                Console.WriteLine("Видалено!");
            else
                Console.WriteLine("Не знайдено!");
        }
    }
}
