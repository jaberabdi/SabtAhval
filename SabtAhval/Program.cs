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
            Console.WriteLine("Enter your command:");
            while (true)
            {
                Console.Write(" cmd>> ");
                var command = Console.ReadLine().Split(' ');
                Person _person;
                switch (command[0].ToLower())
                {
                    case "insert":
                        if (command.Length < 5)
                        {
                            DataController.AddErrorMessage();
                            break;
                        }

                        _person = new Person(command[1], command[2], command[3], DateTime.Parse(command[4]));
                        DataController.Insert(_person);
                        break;
                    case "delete":
                        if (command.Length < 2)
                        {
                            DataController.DeleteErrorMessage();
                            break;
                        }

                        _person = new Person(command[1]);
                        DataController.Delete(_person);
                        break;
                    case "list":
                        if (command.Length < 2)
                        {
                            DataController.ListErrorMessage();
                            break;
                        }
                        _person = new Person(command[1]);
                        Person[] temp = DataController.List(_person);
                        if (temp.Length == 0){
                            Console.WriteLine("No Person found");
	                    }
                        else{
                            foreach (var item in temp){
                                Console.WriteLine(item);
	                        }
                        }
                        break;
                    case "update":
                        if (command.Length < 3)
                        {
                            DataController.UpdateErrorMessage();
                            break;
                        }
                        _person = new Person(command[1], command[2], command[3], DateTime.Parse(command[4]));
                        DataController.Update(_person);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("command not recognized!");
                        break;
                }
            }
        }
    }
}
