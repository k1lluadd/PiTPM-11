using System;
using System.Linq;

namespace Lab11_Console
{
    class Program
    {
        static TrainService trainService = new TrainService();
        static CustomerService customerService = new CustomerService();

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №11, Гаврилов Артём, Ис24");
                Console.WriteLine("1. Вариант 1: Управление поездами");
                Console.WriteLine("2. Вариант 2: Управление клиентами");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите вариант: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RunTrainApp(); break;
                    case "2": RunCustomerApp(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод"); Console.ReadKey(); break;
                }
            }
        }

        static void RunTrainApp()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ПОЕЗДА");
                Console.WriteLine("1. Добавить поезд");
                Console.WriteLine("2. Показать все");
                Console.WriteLine("3. Сортировка по номеру");
                Console.WriteLine("4. Сортировка по станции");
                Console.WriteLine("5. Поиск по номеру");
                Console.WriteLine("6. Сохранить в файл");
                Console.WriteLine("7. Загрузить из файла");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Пункт назначения: "); string dest = Console.ReadLine();
                        Console.Write("Номер поезда: "); int num = int.Parse(Console.ReadLine());
                        Console.Write("Время отправления (HH:mm): "); DateTime time = DateTime.Parse(Console.ReadLine());
                        trainService.AddTrain(dest, num, time);
                        break;
                    case "2":
                        foreach (var t in trainService.Trains) Console.WriteLine(t);
                        break;
                    case "3": trainService.SortByNumber(); break;
                    case "4": trainService.SortByDestination(); break;
                    case "5":
                        Console.Write("Номер поезда для поиска: ");
                        int sNum = int.Parse(Console.ReadLine());
                        var found = trainService.FindByNumber(sNum);
                        if (found != null) Console.WriteLine(found); else Console.WriteLine("Не найден.");
                        break;
                    case "6": trainService.SaveToFile(); break;
                    case "7": trainService.LoadFromFile(); break;
                    case "0": return;
                }
                Console.WriteLine("\nНажмите Enter...");
                Console.ReadKey();
            }
        }

        static void RunCustomerApp()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("КЛИЕНТЫ");
                Console.WriteLine("1. Добавить клиента");
                Console.WriteLine("2. Показать всех");
                Console.WriteLine("3. Сортировка по Имени");
                Console.WriteLine("4. Фильтр по номеру карты (диапазон)");
                Console.WriteLine("5. Поиск по Имени");
                Console.WriteLine("6. Сохранить в файл");
                Console.WriteLine("7. Загрузить из файла");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш выбор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Фамилия: "); string s = Console.ReadLine();
                        Console.Write("Имя: "); string n = Console.ReadLine();
                        Console.Write("Отчество: "); string p = Console.ReadLine();
                        Console.Write("Адрес: "); string a = Console.ReadLine();
                        Console.Write("Номер карты: "); string card = Console.ReadLine();
                        Console.Write("Номер счета: "); string acc = Console.ReadLine();
                        customerService.AddCustomer(s, n, p, a, card, acc);
                        break;
                    case "2":
                        foreach (var c in customerService.Customers) Console.WriteLine(c + "\n");
                        break;
                    case "3": customerService.SortByName(); break;
                    case "4":
                        Console.Write("Мин. номер карты (число): "); ulong min = ulong.Parse(Console.ReadLine());
                        Console.Write("Макс. номер карты (число): "); ulong max = ulong.Parse(Console.ReadLine());
                        var filtered = customerService.FilterByCardRange(min, max);
                        foreach (var c in filtered) Console.WriteLine(c + "\n");
                        break;
                    case "5":
                        Console.Write("Имя для поиска: "); string name = Console.ReadLine();
                        var foundList = customerService.FindByName(name);
                        if (foundList.Count > 0)
                            foreach (var c in foundList) Console.WriteLine(c + "\n");
                        else Console.WriteLine("Не найдено.");
                        break;
                    case "6": customerService.SaveToFile(); break;
                    case "7": customerService.LoadFromFile(); break;
                    case "0": return;
                }
                Console.WriteLine("\nНажмите Enter...");
                Console.ReadKey();
            }
        }
    }
}