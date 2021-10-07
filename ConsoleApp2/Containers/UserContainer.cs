using System;
using System.Collections.Generic;
using System.Text;

using ConsoleApp2.models;
namespace ConsoleApp2.Containers
{
    [Serializable]
    class UserContainer
    {
        private List<User> users = new List<User>();

        public UserContainer() { }
        public UserContainer(List<User> users)
        {
            this.users = users;
        }
        

        public void AddUser(User user)
        {
            users.Add(user);
        }

        

        public List<User> GetUsersByFio(String name, String surname, String otchestvo) =>
            users.FindAll(user => user.EqualByFio(name, surname, otchestvo));
          
   


        public User GetUserByPassportNumber(Int32 passportNumber) =>
            users.Find(user => user.EqualByPassportNumber(passportNumber));


        public List<User> GetUsersByName(String name) =>
            users.FindAll(user => user.EqualByName(name));

        public List<User> GetUsersBySurname(String surname) =>
           users.FindAll(user => user.EqualByName(surname));

        public List<User> GetUsersByOtchestvo(String otchestvo) =>
           users.FindAll(user => user.EqualByName(otchestvo));

        public List<User> GetUsersByDateOfBirth(DateTime dateOfBirth) =>
            users.FindAll(user => user.EqualByDateOfBirth(dateOfBirth));

    }
}
