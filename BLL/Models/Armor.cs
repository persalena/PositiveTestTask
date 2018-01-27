using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Armor : HeroItem<Armor>
    {
        public Armor(double minStateBonus, double maxStateBonus, double cost) : base(minStateBonus, maxStateBonus, cost)
        {

        }
    }
}
