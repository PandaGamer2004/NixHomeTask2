using System;
using System.Collections.Generic;
using System.Text;


using ConsoleApp2.Utils;
using ConsoleApp2.models;
namespace ConsoleApp2
{
    class Application
    {
        private static Application appInstance = new Application();
        private Identity userIdentity = new Identity();

        public Identity Identity => userIdentity;
        
        private Application() {

         
        }

        public static Application getSingeltonApplication()
        {
            return appInstance;
        }
    }
}
