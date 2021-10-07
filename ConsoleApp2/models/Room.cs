using System;
using System.Collections.Generic;
using System.Text;


using ConsoleApp2.Utils;

namespace ConsoleApp2.models
{
    [Serializable]
    public enum MoneyType
    {
        USD,
        RUB,
        UAH
    }
    [Serializable]
    class Room
    {
        private static Identity identity = new Identity(0,1); 
        private Int32 id;
        private MoneyType moneyType;
        private short roomNumber;
        private Category roomCategory;
        private float roomPrice;

        public int Id { get => id; }
        public short RoomNumber { get => roomNumber; set => roomNumber = value; }

        public Room(short roomNumber, Category roomCategory, float roomPrice) : this()
        {
            this.roomNumber = roomNumber;
            this.roomCategory = roomCategory;
            this.roomPrice = roomPrice;
        }

        public Room() {
            this.id = identity.GetNextValue();
        }


        public static short GetRoomNumberFromConsole()
        {
            short roomNumber;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите номер комнаты: ");
                    var inputStr = Console.ReadLine();
                    var roomNumberFromInput = (short)Int32.Parse(inputStr);

                    roomNumber = roomNumberFromInput;
                    break;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите номер комнаты в виде числа. Пример: 12");
                }
            }
            return roomNumber;
        }
        public void GetRoomFromConsole()
        {
            this.roomNumber = GetRoomNumberFromConsole();


            var categoryFromInput = new Category();
            categoryFromInput.GetCategoryFromConsole();

            this.roomCategory = categoryFromInput;

            while (true)
            {

                try
                {
                    Console.WriteLine("Введите стоимость комнаты без знака валюты: ");
                    var inputSting = String.Join("", Console.ReadLine().Trim().Split(" "));
                    var lastChar = inputSting[inputSting.Length - 1];

                    Single priceFromInput;
                    if (!(lastChar >= '0' && lastChar <= '9'))
                    {
                        inputSting = inputSting.Substring(0, inputSting.Length - 1);
                    }

                    priceFromInput = Single.Parse(inputSting);


                    
                    this.roomPrice = priceFromInput;
                    this.moneyType = EnumUtils.GetEnumTypeFromConsole<MoneyType>("Введите тип валюты(UAH, USD, RUB): ", "Введите верно тип валюты!");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите стоимость комнаты в виде числа. Пример 12000");
                }
            }
        }

        
        public override string ToString()
        {
            return $"Номер комнаты: {roomNumber}\nКатегория комнаты:{roomCategory}\nСтоимость комнаты {roomPrice}{moneyType}";
        }
    }
}
