using System;
using System.Collections.Generic;
using System.Text;


using ConsoleApp2.Utils;
using ConsoleApp2.Containers;
using ConsoleApp2.models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp2
{
    [Serializable]
    class Application
    {
        private static Application appInstance = new Application();
        private RoomOccupationAndInfoContainer occupatedRoomsConatiner = new RoomOccupationAndInfoContainer();
        private UserContainer usersContainer = new UserContainer();
        private RoomContainer roomsContainer = new RoomContainer();
        private User loggedInUser;
        
        
        private Application() {
               
        }
       
        protected void SerializeApplication()
        {

            using (FileStream fs = new FileStream("application.dat", FileMode.OpenOrCreate, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(fs, this);

            };
        }
        public static Application getSingeltonApplication()
        {
            return appInstance;
        }

        protected User CreateAndAddUser()
        {
            var user = new User();
            user.GetUserFromConsole();
            usersContainer.AddUser(user);
            return user;
        }

        protected void CreateAndAddRoom()
        {
            var room = new Room();
            room.GetRoomFromConsole();
            roomsContainer.AddRoom(room);
        }



        protected void BookOrMakeBusyAndAddRoom(RoomOccupation occupation)
        {

            
            DateTime dateFrom;
            DateTime dateTo;
            
            GetDateFromConsole(out dateFrom, out dateTo, occupation);


            if(occupation == RoomOccupation.Busy)
            {
                var occup = occupatedRoomsConatiner.getRoomOccupationAndInfoItem(loggedInUser.Id, dateFrom, dateTo);
                if(occup!= null)
                {
                    if (occup.RoomOccupation == RoomOccupation.Busy) Console.WriteLine("Вы уже заселились в этот номер!");
                    occup.RoomOccupation = occupation;
                    return;
                }
            }

            var occupatedRoomsId = occupatedRoomsConatiner.getAllOccupatedRoomsId(dateFrom, dateTo);

            var freeRooms = roomsContainer.GetRoomsExceptedById(occupatedRoomsId);


            if (freeRooms.Count == 0)
            {
                Console.WriteLine("Свободных комнат на данную дату нет");
                return;
            }

            freeRooms.ForEach(room => Console.WriteLine(room));

            Int32 selectedRoomNumber;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите номер комнаты которую вы хотите забронировать: ");
                    selectedRoomNumber = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите числом номер комнаты!");
                }
            }

            var selectedRoom = freeRooms.Find(room => room.RoomNumber == selectedRoomNumber);
            CreateAndAddRoomOccupationAndInfoItem(occupation, selectedRoom.Id, dateFrom, dateTo);
        }

        protected void GetDateFromConsole(out DateTime dateFrom, out DateTime dateTo, RoomOccupation op)
        {
            while (true)
            {
                try
                {
                    if (op == RoomOccupation.Busy)
                    {
                        dateFrom = DateTime.Now;
                    }
                    else
                    {
                        Console.WriteLine("Введите дату заселения: ");
                        dateFrom = DateTime.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Введите дату выселения: ");

                    dateTo = DateTime.Parse(Console.ReadLine());
                    break;

                }
                catch (FormatException)
                {
                    Console.Write("Введите дату в правильном формате. Пример: 04.04.2003");
                }

            }
        }

        protected void CreateAndAddRoomOccupationAndInfoItem(RoomOccupation oc,Int32 roomId, DateTime from, DateTime to)
        {
            var item = new RoomOccupationAndInfoItem(oc, loggedInUser.Id,roomId, from, to);
            occupatedRoomsConatiner.addOccupatedRoom(item);
        }
        protected void MenuLogic(ref bool continueRead)
        {
            Console.WriteLine($"|Добавить комнату|Забронировать комнату на дату|Заселится в комнату|Выйти|Завершить работу");

            var inputString = Console.ReadLine().Trim().ToLower();

            switch (inputString)
            {
                case "создать пользователя":
                    CreateAndAddUser();
                    break;

                case "добавить комнату":
                    CreateAndAddRoom();
                    break;

                case "забронировать комнату на дату":
                    BookOrMakeBusyAndAddRoom(RoomOccupation.Booked);
                    break;

                case "Заселится в комнату":
                    BookOrMakeBusyAndAddRoom(RoomOccupation.Busy);
                    break;
                case "Выйти":
                    loggedInUser = null;
                    break;
                case "завершить работу":
                    continueRead = false;
                    loggedInUser = null;
                    SerializeApplication();
                    break;
            }
                   
        }

        protected void LogIn()
        {
            Console.WriteLine("Войти|Создать пользователя");
            var strFromInput = Console.ReadLine().Trim().ToLower();
            if(strFromInput == "войти")
            {
                for(int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Осталось попыток для ввода: {3 -i}" ); 
                    var number = User.GetPassportNumbeFromConsole();
                    var selectedUser = usersContainer.GetUserByPassportNumber(number);
                    if(selectedUser == null)
                    {
                        Console.WriteLine("Не существует такого пользователя.");
                    }
                    this.loggedInUser = selectedUser;

                }

                }
            else
                {
                var createdUser = CreateAndAddUser();
                this.loggedInUser = createdUser;
            }

            Console.Clear();   
        }

        public void RunApplication()
        {
            bool continueRead = true;

         
            while (continueRead)
            {
                Console.Clear();
                if(loggedInUser == null) LogIn();
                

                if(loggedInUser != null) MenuLogic(ref continueRead);


                
            }
        }
    }
}
