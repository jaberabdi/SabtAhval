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
                Person _person;
                switch (command[0].ToLower())
                {
                    case "add":
                        // check input
                        if (command.Length < 5)
                        {
                            DataController.AddErrorMessage();
                        }
                        _person = new Person(command[1],command[2],command[3],DateTime.Parse(command[4]));
                        DataController.Add(_person);
                        break;
                    case "delete":
                        // check input
                        _person = new Person(command[1], command[2], command[3], DateTime.Parse(command[4]));
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
