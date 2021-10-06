using System;
using System.Collections.Generic;
using System.Text;




namespace ConsoleApp2.models
{

    public enum MoneyType
    {
        USD,
        RUB,
        UAH
    }
    class Room
    {
        private Int32 id;
        private MoneyType moneyType;
        private short roomNumber;
        private Category roomCategory;
        private float roomPrice;

        public Room(short roomNumber, Category roomCategory, float roomPrice)
        {
            id = Application.getSingeltonApplication().Identity.GetNextValue(this.GetType());
            this.roomNumber = roomNumber;
            this.roomCategory = roomCategory;
            this.roomPrice = roomPrice;
        }




        public void GetRoomFromConsole()
        {
            id = Application.getSingeltonApplication().Identity.GetNextValue(this.GetType());
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


            var categoryFromInput = new Category();
            categoryFromInput.GetCategoryFromConsole();


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


                    Console.WriteLine("Введите тип валюты(UAH, USD, RUB): ");
                    var moneyTypeFromInput = Console.ReadLine().Trim().ToLower();
                    var tp = moneyTypeFromInput switch
                    {
                        "usd" => MoneyType.USD,
                        "rub" => MoneyType.RUB,
                        _ => MoneyType.UAH,
                    };

                    this.roomPrice = priceFromInput;
                    this.moneyType = tp;

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите стоимость комнаты в виде числа. Пример 12000");
                }
            }
        }
        }
}
