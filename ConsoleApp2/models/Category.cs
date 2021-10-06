using System;
using System.Collections.Generic;
using System.Text;

using ConsoleApp2.Extentions;

namespace ConsoleApp2.models
{


    public enum RoomCategoryPlacing
    {
        SGL,
        DBL,
        TRPL,
        QDPL,
        ExB,
        CH,
        BO,ROH
    }

    public enum RoomCategoryType
    {
        ECN,
        STD,
        LUX
    }

    public enum RoomCategoryView
    {
        City,
        Sea,
        Park,
        Valley
    }
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
            Application.getSingeltonApplication().Identity.InitType(this.GetType(), 0, 1);
        }

        internal void GetCategoryFromConsole()
        {

            Enum helperEnum = default;
            this.roomPlacing = helperEnum.GetEnumTypeFromConsole<RoomCategoryPlacing>(String.Format("Введите тип размещения номера({0})", String.Join(" ", Enum.GetValues(typeof(RoomCategoryPlacing)))),
                "Введите верно тип размещения!!!");

            this.roomView = helperEnum.GetEnumTypeFromConsole<RoomCategoryView>(String.Format("Введите тип вида из номера({0})", String.Join(" ", Enum.GetValues(typeof(RoomCategoryView)))),
               "Введите верно тип вида!!!");

            this.roomType= helperEnum.GetEnumTypeFromConsole<RoomCategoryType>(String.Format("Введите тип номера({0})", String.Join(" ", Enum.GetValues(typeof(RoomCategoryType)))),
               "Введите верно тип номера!!!");

        }
    }
}
