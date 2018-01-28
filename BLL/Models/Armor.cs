using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Armor : HeroItem<Armor>
    {
        public Armor(int minStateBonus, int maxStateBonus, int cost) : base(minStateBonus, maxStateBonus, cost)
        {

        }
    }
}
