// Варіант 5

using System;
using System.ComponentModel;

namespace ConsoleSample
{
    class Program
    {
        class Phone
        {
            private List<string> calls = new List<string>();    // список, в який записуються дзвінки

            // Перелік тарифів
            public enum Tariff : int
            {
                Bronze = 1,
                Silver = 2,
                Gold = 3,
                Platinum = 4,
            }

            // Перелік послуг
            public enum Services : int
            {
                FreeCall = 1,
                FreeSMS = 2,
                ExtraMB = 3,
                ExtraMinutes = 4
            }
            Services[] services = new Services[4];

            Tariff tariffPlan;      // тарифний план
            double pricePerMinute;  // вартість хвилини розмови
            double money;           // поточна сума коштів на рахунку 
            string phoneNumber;     // номер телефону

            // Конструктор за замовчуванням
            public Phone()
            {
                tariffPlan = Tariff.Bronze;
                pricePerMinute = 0.50;
                money = 40;
                phoneNumber = "0000000001";
            }

            // Конструктор з параметрами
            public Phone(Tariff tariff, double money, string phoneNumber)
            {
                tariffPlan = tariff;
                pricePerMinute = 0.50;
                this.money = money;
                this.phoneNumber = phoneNumber;
            }

            // Метод переходу на новий тарифний план
            public void newTariff(Tariff tariff)
            {
                tariffPlan = tariff;
            }

            // Функція здійснення дзвінка
            public double call(int minutes, string phoneNumber)
            {
                double pricePerCall = minutes * pricePerMinute;
                if (money > 0)
                {
                    string call = phoneNumber + " " + minutes + " хвилин";
                    calls.Add(call);
                    money -= pricePerCall;
                }
                else
                {
                    money = 0;
                    Console.WriteLine("Недостатньо коштiв для дзвiнка!");
                }
                return pricePerCall;
            }

            // Метод підключення послуги
            public void activateService(Services service)
            {
                if (money >= 10)
                {
                    switch (service)
                    {
                        case Services.FreeCall:
                            money -= 10;
                            services[0] = Services.FreeCall;
                            Console.WriteLine("Послугу \"Безкоштовні дзвінки\" підключено!");
                            break;

                        case Services.FreeSMS:
                            money -= 10;
                            services[1] = Services.FreeSMS;
                            Console.WriteLine("Послугу \"Безкоштовні СМС\" підключено!");
                            break;

                        case Services.ExtraMB: 
                            if (money >= 20)
                            {
                                money -= 20;
                                services[2] = Services.ExtraMB;
                                Console.WriteLine("Послугу \"Додаткові мегабайти\" підключено!");
                            }
                            break;
                        case Services.ExtraMinutes:
                            if (money >= 20)
                            {
                                money -= 20;
                                services[3] = Services.ExtraMinutes;
                                Console.WriteLine("Послугу \"Додаткові хвилини\" підключено!");
                            }
                            break;
                    }
                }
            }

            // Метод відключення послуги
            public void deactivateService(Services service)
            {
                switch (service)
                {
                    case Services.FreeCall:
                        services[0] = 0;
                        Console.WriteLine("Послугу \"Безкоштовні дзвінки\" відключено!");
                        break;

                    case Services.FreeSMS:
                        services[1] = 0;
                        Console.WriteLine("Послугу \"Безкоштовні СМС\" відключено!");
                        break;

                    case Services.ExtraMB:
                        services[2] = 0;
                        Console.WriteLine("Послугу \"Додаткові мегабайти\" відключено!");
                        break;
                    case Services.ExtraMinutes:
                        services[3] = 0;
                        Console.WriteLine("Послугу \"Додаткові хвилини\" відключено!");
                        break;
                }
            }

            //Метод поповнення поточного рахунку
            public void putMoney(int amount)
            {
                if (amount > 0) money += amount;
                Console.WriteLine("На рахунок зараховано " + amount);
            }

            // Метод отримання поточного стану рахунку
            public void showMoney()
            {
                Console.WriteLine("На рахунку " + money);
            }

            // Метод перегляду історії дзвінків
            public void showCalls()
            {
                Console.WriteLine("Iсторiя викликiв:");
                foreach (var calls in calls)
                {
                    Console.WriteLine(calls);
                }
            }
        }

        static void Main()
        {
            Phone phone = new Phone();          // створення екземпляру класу Phone
            phone.showMoney();                  // перевірка стану рахунку
            phone.newTariff(Phone.Tariff.Gold); // зміна тарифу
            phone.call(14, "4523155325");       // здійснення дзвінка
            phone.activateService(Phone.Services.FreeCall);     // підключення послуги
            phone.call(7, "2325890394");        // здійснення дзвінка
            phone.deactivateService(Phone.Services.FreeCall);   // відключення послуги
            phone.putMoney(200);                // поповнення рахунку
            phone.showMoney();
            phone.showCalls();                  // перегляд історії дзвінків
        }
    }
}