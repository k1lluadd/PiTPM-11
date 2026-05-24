using System;

namespace Lab11_Console
{
    [Serializable]
    public class Train
    {
        public string Destination { get; set; }
        public int TrainNumber { get; set; }
        public DateTime DepartureTime { get; set; }

        public Train() { }

        public Train(string destination, int number, DateTime time)
        {
            Destination = destination;
            TrainNumber = number;
            DepartureTime = time;
        }

        public override string ToString() =>
            $"№{TrainNumber,-5} | {Destination,-15} | Отправление: {DepartureTime:HH:mm}";
    }

    [Serializable]
    public class Customer
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string CreditCardNumber { get; set; }
        public string BankAccountNumber { get; set; }

        public Customer() { }

        public Customer(string surname, string name, string patronymic, string address, string card, string account)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Address = address;
            CreditCardNumber = card;
            BankAccountNumber = account;
        }

        public override string ToString() =>
            $"{Surname} {Name} {Patronymic}\n   Карта: {CreditCardNumber} | Счет: {BankAccountNumber}";
    }
}