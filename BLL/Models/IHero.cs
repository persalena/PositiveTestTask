using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public interface IHero
    {
        int Power { get; }
        int Health { get; }
        int MaxHealth { get; }
        int Money { get; }

        int WeaponCount { get; }
        int ArmorCount { get; }

        ActionResult Attack();
        ActionResult BuyWeapon();
        ActionResult BuyArmor();
        ActionResult RestoreHealth();
    }
}
