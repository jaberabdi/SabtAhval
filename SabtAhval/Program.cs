using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabtAhval
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your command:");
                Console.Write(" cmd>> ");
                string[] command = Console.ReadLine().Split(' ');
                switch(command[0].ToLower())
                {
                    case "add":
                        // check input
                        Person _person = new Person();
                        DataController.Add(_person);
                        break;
                    case "delete":
                        break;
                    case "list":
                        break;
                    case "update":
                        break;
                    case "exit":
                        return;
                }
            }
        }
    }
}
