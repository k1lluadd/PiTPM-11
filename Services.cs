using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab11_Console
{
    public class TrainService
    {
        public List<Train> Trains { get; private set; } = new List<Train>();
        private readonly string _filePath = "trains.dat";

        public void AddTrain(string dest, int num, DateTime time)
        {
            Trains.Add(new Train(dest, num, time));
        }

        public void SortByNumber()
        {
            Trains = Trains.OrderBy(t => t.TrainNumber).ToList();
            Console.WriteLine("Отсортировано по номеру.");
        }

        public void SortByDestination()
        {
            Trains = Trains.OrderBy(t => t.Destination).ToList();
            Console.WriteLine("Отсортировано по пункту назначения.");
        }

        public Train FindByNumber(int number)
        {
            return Trains.FirstOrDefault(t => t.TrainNumber == number);
        }

        public void SaveToFile()
        {
            try
            {
                using (var fs = new FileStream(_filePath, FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, Trains);
                }
                Console.WriteLine("Данные поездов сохранены!");
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка сохранения: {ex.Message}"); }
        }

        public void LoadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            try
            {
                using (var fs = new FileStream(_filePath, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var loaded = (List<Train>)formatter.Deserialize(fs);
                    Trains.AddRange(loaded);
                }
                Console.WriteLine("Данные поездов загружены!");
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка загрузки: {ex.Message}"); }
        }
    }

    public class CustomerService
    {
        public List<Customer> Customers { get; private set; } = new List<Customer>();
        private readonly string _filePath = "customers.dat";

        public void AddCustomer(string surname, string name, string patronymic, string address, string card, string account)
        {
            Customers.Add(new Customer(surname, name, patronymic, address, card, account));
        }

        public void SortByName()
        {
            Customers = Customers.OrderBy(c => c.Name).ToList();
            Console.WriteLine("Отсортировано по имени.");
        }

        public List<Customer> FilterByCardRange(ulong min, ulong max)
        {
            return Customers.Where(c =>
            {
                string cleanNum = c.CreditCardNumber.Replace(" ", "").Replace("-", "");
                if (ulong.TryParse(cleanNum, out ulong num))
                    return num >= min && num <= max;
                return false;
            }).ToList();
        }

        public List<Customer> FindByName(string name)
        {
            return Customers.Where(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void SaveToFile()
        {
            try
            {
                using (var fs = new FileStream(_filePath, FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, Customers);
                }
                Console.WriteLine("Данные клиентов сохранены!");
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка сохранения: {ex.Message}"); }
        }

        public void LoadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            try
            {
                using (var fs = new FileStream(_filePath, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var loaded = (List<Customer>)formatter.Deserialize(fs);
                    Customers.AddRange(loaded);
                }
                Console.WriteLine("Данные клиентов загружены!");
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка загрузки: {ex.Message}"); }
        }
    }
}