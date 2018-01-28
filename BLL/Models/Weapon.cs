using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Weapon:HeroItem<Weapon>
    {
        public Weapon(int minStateBonus, int maxStateBonus, int cost) : base(minStateBonus, maxStateBonus, cost)
        {

        }
    }
}
