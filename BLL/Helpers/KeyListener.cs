using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class KeyListener
    {
        public KeyListener()
        {

        }

        public void Init()
        {
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            };

            Console.WriteLine("Press ESC to Exit");

            var taskKeys = new Task(ReadKeys);
            taskKeys.Start();

            var tasks = new[] { taskKeys };
            Task.WaitAll(tasks);
        }

        private static void ReadKeys()
        {
            var hero = new Hero(100,1,2);

            var key = new ConsoleKeyInfo();

            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        Console.WriteLine("W was pressed");
                        hero.Attack();
                        break;
                    case ConsoleKey.A:
                        hero.BuyWeapon();
                        Console.WriteLine("A was pressed");
                        break;

                    case ConsoleKey.D:
                        Console.WriteLine("D was pressed");
                        break;

                    case ConsoleKey.S:
                        Console.WriteLine("S was pressed");
                        break;

                    case ConsoleKey.Escape:
                        break;

                    default:
                        if (Console.CapsLock && Console.NumberLock)
                        {
                            Console.WriteLine(key.KeyChar);
                        }
                        break;
                }
            }
        }
    }
}

