using BLL.Enums;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class DisplayResultHelper:IDisplayResultHelper
    {
        private void _showHeroStats(IHero hero)
        {
            Console.WriteLine("Health: {0}/{1}", hero.Health, hero.MaxHealth);
            Console.WriteLine("Money: {0}", hero.Money);
            Console.WriteLine("Power: {0}", hero.Power);
            Console.WriteLine("Weapons: {0}", hero.WeaponCount);
            Console.WriteLine("Armors: {0}", hero.ArmorCount);
            Console.WriteLine();
        }

        public void ShowResult(ActionResult actionResult, IHero hero)
        {
            switch (actionResult.Code)
            {
                case ResultCode.Win:
                    {
                        Console.WriteLine("Congratulations! You win!");
                        break;
                    }
                case ResultCode.Loose:
                    {
                        Console.WriteLine("Sorry, but you loose!");
                        break;
                    }
                case ResultCode.NotEnoughMoney:
                    {
                        Console.WriteLine("You have not got enough money!");
                        break;
                    }
                case ResultCode.ItemBought:
                    {
                        Console.WriteLine("Success byuing!");
                        break;
                    }
            }

            this._showHeroStats(hero);
        }
    }
}
