using DoctorAppointment.Storage;
using DoctorAppointment.Services;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Оберіть формат зберігання:");
        Console.WriteLine("1 — JSON");
        Console.WriteLine("2 — XML");
        Console.Write("Ваш вибір: ");

        string choice = Console.ReadLine();

        IStorage storage = choice == "2"
            ? new XmlStorage()
            : new JsonStorage();

        var doctorService = new DoctorService(storage);
        var patientService = new PatientService(storage);
        var appointmentService = new AppointmentService(storage);

        while (true)
        {
            Console.WriteLine("\n--- МЕНЮ ---");
            Console.WriteLine("1. Лікарі");
            Console.WriteLine("2. Пацієнти");
            Console.WriteLine("3. Записи");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            string menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    DoctorMenu(doctorService);
                    break;
                case "2":
                    PatientMenu(patientService);
                    break;
                case "3":
                    AppointmentMenu(appointmentService);
                    break;
                case "0":
                    return;
            }
        }
    }

    static void DoctorMenu(DoctorService s)
    {
        Console.WriteLine("\n--- ЛІКАРІ ---");
        Console.WriteLine("1. Показати всіх");
        Console.WriteLine("2. Додати");
        Console.WriteLine("3. Оновити");
        Console.WriteLine("4. Видалити");
        Console.Write("Ваш вибір: ");

        switch (Console.ReadLine())
        {
            case "1": s.ShowAll(); break;
            case "2": s.Add(); break;
            case "3": s.Update(); break;
            case "4": s.Delete(); break;
        }
    }

    static void PatientMenu(PatientService s)
    {
        Console.WriteLine("\n--- ПАЦІЄНТИ ---");
        Console.WriteLine("1. Показати всіх");
        Console.WriteLine("2. Додати");
        Console.WriteLine("3. Оновити");
        Console.WriteLine("4. Видалити");
        Console.Write("Ваш вибір: ");

        switch (Console.ReadLine())
        {
            case "1": s.ShowAll(); break;
            case "2": s.Add(); break;
            case "3": s.Update(); break;
            case "4": s.Delete(); break;
        }
    }

    static void AppointmentMenu(AppointmentService s)
    {
        Console.WriteLine("\n--- ЗАПИСИ ---");
        Console.WriteLine("1. Показати всі");
        Console.WriteLine("2. Додати");
        Console.WriteLine("3. Оновити");
        Console.WriteLine("4. Видалити");
        Console.Write("Ваш вибір: ");

        switch (Console.ReadLine())
        {
            case "1": s.ShowAll(); break;
            case "2": s.Add(); break;
            case "3": s.Update(); break;
            case "4": s.Delete(); break;
        }
    }
}
