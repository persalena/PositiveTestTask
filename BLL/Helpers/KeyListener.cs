using Autofac;
using BLL.Enums;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class KeyListener:IKeyListener
    {
        public void Init()
        {           
            Task<TaskExitCode> keyTask = null;

            do
            {
                Console.WriteLine("[NEW GAME STARTED]");
                Console.WriteLine("...Press W to Attack monster");
                Console.WriteLine("...Press A to Buy weapon");
                Console.WriteLine("...Press D to Buy armor");
                Console.WriteLine("...Press S to Reatore health");
                Console.WriteLine("...Press ESC to Exit");

                keyTask = new Task<TaskExitCode>(ReadKeys);
                keyTask.Start();

                var tasks = new[] { keyTask };
                Task.WaitAll(keyTask);

            } while (keyTask.Result == TaskExitCode.GameOver);
            
        }

        private static TaskExitCode ReadKeys()
        {
            var key = new ConsoleKeyInfo();
            var hero = IoC.Instance.Resolve<IHero>();
            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape && hero.Health > 0)
            {
                key = Console.ReadKey(true);
                ActionResult result = null;
                
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        Console.WriteLine("Monster Attack");
                        result = hero.Attack();
                        break;

                    case ConsoleKey.A:
                        Console.WriteLine("Buy wapon");
                        result = hero.BuyWeapon();
                        break;

                    case ConsoleKey.D:
                        Console.WriteLine("Buy Armor");
                        result = hero.BuyArmor();
                        break;

                    case ConsoleKey.S:
                        Console.WriteLine("Healing");
                        result = hero.RestoreHealth();
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
                if (result != null)
                {
                    var displayResultHelper = IoC.Instance.Resolve<IDisplayResultHelper>();
                    displayResultHelper.ShowResult(result, hero);
                }
            }

            if(hero.Health <= 0)
            {
                Console.WriteLine("[Oops! GAME OVER]");
                return TaskExitCode.GameOver;
            }
            else
            {
                return TaskExitCode.Quit;
            }
        }
    }
}

