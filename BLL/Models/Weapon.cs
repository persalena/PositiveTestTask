using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Weapon:HeroItem<Weapon>
    {
        public Weapon(double minStateBonus, double maxStateBonus, double cost) : base(minStateBonus, maxStateBonus, cost)
        {

        }
    }
}
