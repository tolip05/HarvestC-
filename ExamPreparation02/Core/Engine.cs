using ExamPreparation02.BusnesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamPreparation02.Core
{
   public class Engine
    {
        

        public void Run()
        {
            DraftManager manager = new DraftManager();
            string input = Console.ReadLine();
            while (input != "ShutDown")
            {
                var arguments = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var command = arguments[0];
                arguments = arguments.Skip(1).ToList();
                switch (command)
                {
                    case "RegisterHarvester":
                        Console.WriteLine( manager.RegisterHarvester(arguments));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(manager.RegisterProvider(arguments));
                        break;
                        case "Day":
                        Console.WriteLine(manager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(manager.Mode(arguments));
                        break;
                    
                    case "Check":
                        Console.WriteLine(manager.Check(arguments));
                        break;
                    
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(manager.ShutDown());
        }
    }
}
