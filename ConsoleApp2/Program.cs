using System;

using System.Collections.Generic;


using ConsoleApp2.models;
using ConsoleApp2.Containers;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp2
{
    class Program
    {
        private static string filePath = "application.dat";
        static void Main(string[] args)
        {
            FileStream fs = null;
            Application app = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var formatter = new BinaryFormatter();
                app = (Application)formatter.Deserialize(fs);
            }
            catch(FileNotFoundException)
            {
                app = Application.getSingeltonApplication();
            }
            finally
            {
                fs?.Close();
            }

                app.RunApplication();
            
            
        }
    }
}
