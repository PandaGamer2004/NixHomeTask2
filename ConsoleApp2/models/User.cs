using System;

using ConsoleApp2.Utils;


namespace ConsoleApp2.models
{
    [Serializable]
    class User
    {
        private static Identity identity = new Identity(0, 1);
        private Int32 id;
        private String name;
        private String surname;
        //TODO напиши нормально
        private String otchestvo;
        private Int32 passportNumber;
        private DateTime dateOfBirth;

        public int Id { get => id;}

        public User() {
            this.id = identity.GetNextValue();
        }
       
        public User(string name, string surname, string otchestvo, short passportNumber, DateTime dateOfBirth) : this()
        {
            this.name = name;
            this.surname = surname;
            this.otchestvo = otchestvo;
            this.passportNumber = passportNumber;
            this.dateOfBirth = dateOfBirth;
        }

        
        public static Int32 GetPassportNumbeFromConsole()
        {
            Int32 passportNumber = 0;

            bool continueReadPassportNumber = true;
            while (continueReadPassportNumber)
            {
                try
                {
                    Console.WriteLine("Введите номер пасспорта пользователя: ");
                    var inputString = Console.ReadLine();
                    if (inputString.Length != 8)
                    {
                        Console.WriteLine("Длина номера пасспорта не может быть меньше или больше 8!!!");
                        continue;
                    }
                    var passportNumberFromInput = Int32.Parse(inputString);
                    continueReadPassportNumber = false;
                    passportNumber = passportNumberFromInput;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели номер пасспорта в неврном формате! Пример ввода: 12345678");
                }
            }
            return passportNumber;
        }
        public void GetUserFromConsole()
        {
            Console.WriteLine("Введите ФИО пользователя: ");




            while(true){ 
            try
            {
                var fioString = Console.ReadLine().Trim().Split(" ");

                surname = fioString[0];
                name = fioString[1];
                otchestvo = fioString[2];
                break;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Введите верно ФИО. Пример: Пупкин Василий Андреевич");
            }
        }


            this.passportNumber = GetPassportNumbeFromConsole();
            
            bool continueReadDateOfBirth = true;


            while (continueReadDateOfBirth)
            {
                try
                {
                    Console.WriteLine("Введите дату рождения: ");
                    var dateOfBitrhFromInput = DateTime.Parse(Console.ReadLine());
                    continueReadDateOfBirth = false;
                    dateOfBirth = dateOfBitrhFromInput;
                }catch(FormatException)
                {
                    Console.WriteLine(@"Введите дату рождения в верном формате. Пример: 04.04.2003");
                }
            }
        }

        public bool EqualByFio(String name, String surname, String otchestvo)
        {
            return this.name == name && this.surname == surname && this.otchestvo == otchestvo;
        }

        public bool EqualByPassportNumber(Int32 passportNumber)
        {
            return this.passportNumber == passportNumber;
        }

        public bool EqualByDateOfBirth(DateTime dateOfBirth)
        {
            return this.dateOfBirth == dateOfBirth;
        }

        public bool EqualByName(String name) => this.name == name;

        public bool EqualBySurname(String surname) => this.surname == surname;

        public bool EqualByOtchestvo(String otchestvo) => this.otchestvo == otchestvo;

    }
}
