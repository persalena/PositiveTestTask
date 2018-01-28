using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Healing : HeroItem<Healing>
    {
        public Healing(int minStateBonus, int maxStateBonus, int cost) : base(minStateBonus, maxStateBonus, cost)
        {

        }
    }
}
