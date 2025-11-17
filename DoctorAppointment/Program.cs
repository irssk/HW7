using DoctorAppointment.Services;
using System;

namespace DoctorAppointment
{
    enum MenuOption
    {
        Exit = 0,
        Doctors = 1,
        Patients = 2,
        Appointments = 3
    }

    class Program
    {
        static void Main()
        {
            var doctorService = new DoctorService();
            var patientService = new PatientService();
            var appointmentService = new AppointmentService();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n==== МЕНЮ ====");
                Console.WriteLine("1. Лікарі");
                Console.WriteLine("2. Пацієнти");
                Console.WriteLine("3. Записи на прийом");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть пункт: ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out int option))
                    continue;

                switch ((MenuOption)option)
                {
                    case MenuOption.Exit:
                        running = false;
                        break;

                    case MenuOption.Doctors:
                        DoctorMenu(doctorService);
                        break;

                    case MenuOption.Patients:
                        PatientMenu(patientService);
                        break;

                    case MenuOption.Appointments:
                        AppointmentMenu(appointmentService);
                        break;
                }
            }
        }

        static void DoctorMenu(DoctorService service)
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\n-- Лікарі --");
                Console.WriteLine("1. Показати всіх");
                Console.WriteLine("2. Додати");
                Console.WriteLine("3. Оновити");
                Console.WriteLine("4. Видалити");
                Console.WriteLine("0. Назад");

                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: service.ShowAll(); break;
                    case 2: service.Add(); break;
                    case 3: service.Update(); break;
                    case 4: service.Delete(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void PatientMenu(PatientService service)
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\n-- Пацієнти --");
                Console.WriteLine("1. Показати всіх");
                Console.WriteLine("2. Додати");
                Console.WriteLine("3. Оновити");
                Console.WriteLine("4. Видалити");
                Console.WriteLine("0. Назад");

                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: service.ShowAll(); break;
                    case 2: service.Add(); break;
                    case 3: service.Update(); break;
                    case 4: service.Delete(); break;
                    case 0: back = true; break;
                }
            }
        }

        static void AppointmentMenu(AppointmentService service)
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\n-- Записи --");
                Console.WriteLine("1. Показати всі");
                Console.WriteLine("2. Додати");
                Console.WriteLine("3. Оновити");
                Console.WriteLine("4. Видалити");
                Console.WriteLine("0. Назад");

                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: service.ShowAll(); break;
                    case 2: service.Add(); break;
                    case 3: service.Update(); break;
                    case 4: service.Delete(); break;
                    case 0: back = true; break;
                }
            }
        }
    }
}
