using System;
using System.Collections.Generic;
using System.Text;

using ConsoleApp2.Utils;

namespace ConsoleApp2.models
{

    [Serializable]
    public enum RoomCategoryPlacing
    {
        SGL,
        DBL,
        TRPL,
        QDPL
    }

    [Serializable]
    public enum RoomCategoryType
    {
        ECN,
        STD,
        LUX
    }

    [Serializable]
    public enum RoomCategoryView
    {
        City,
        Sea,
        Park,
        Valley
    }
    [Serializable]
    public class Category
    {
        RoomCategoryView roomView;
        RoomCategoryPlacing roomPlacing;
        RoomCategoryType roomType;

        public Category(RoomCategoryView roomView,
            RoomCategoryPlacing roomPlacing, 
            RoomCategoryType roomType)
        {
            this.roomView = roomView;
            this.roomPlacing = roomPlacing;
            this.roomType = roomType;
        }


        public Category() {
            
        }

        public override string ToString()
        {
            return $"\nРазмещение комнаты: {roomPlacing}\nТип комнаты: {roomType}\nВид из комнаты {roomView}";
        }

        internal void GetCategoryFromConsole()
        {

         
            this.roomPlacing = EnumUtils.GetEnumTypeFromConsole<RoomCategoryPlacing>(String.Format("Введите тип размещения номера({0})", String.Join(" ", EnumUtils.GetValues<RoomCategoryPlacing>())),
                "Введите верно тип размещения!!!");

            this.roomView = EnumUtils.GetEnumTypeFromConsole<RoomCategoryView>(String.Format("Введите тип вида из номера({0})", String.Join(" ", EnumUtils.GetValues<RoomCategoryView>())),
               "Введите верно тип вида!!!");

            this.roomType= EnumUtils.GetEnumTypeFromConsole<RoomCategoryType>(String.Format("Введите тип номера({0})", String.Join(" ", EnumUtils.GetValues<RoomCategoryType>())),
               "Введите верно тип номера!!!");

        }
    }
}
