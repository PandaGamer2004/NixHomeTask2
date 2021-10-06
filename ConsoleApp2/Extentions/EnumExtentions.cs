using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Extentions
{
    static class EnumExtentions
    {

        public static TEnum GetEnumTypeFromConsole<TEnum>(this Enum currenEnum, String promptString, String invalidFormatString)
            where TEnum : struct
        {
            TEnum rp;
            String roomPlacingFromInput;
            while (true)
            {
                try
                {
                    Console.WriteLine(promptString);
                    roomPlacingFromInput = Console.ReadLine().Trim();

                    Enum.Parse<TEnum>(roomPlacingFromInput, true);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(invalidFormatString);
                }
            }

            
        } 
    }
}
