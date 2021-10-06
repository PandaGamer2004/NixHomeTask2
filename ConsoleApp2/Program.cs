using System;

using System.Collections.Generic;


using ConsoleApp2.models;
using ConsoleApp2.Containers;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UserContainer();
            var u1 = new User();
            u1.GetUserFromConsole();
            container.AddUser(u1);
            var u2 = new User();
            u2.GetUserFromConsole();
            container.AddUser(u2);
            var u3 = new User();
            u3.GetUserFromConsole();
            container.AddUser(u3);

            var res = container.GetUsersByDateOfBirth(DateTime.Parse("04.04.2003"));

        }
    }
}
