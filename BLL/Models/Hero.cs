using Autofac;
using BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class Hero
    {
        private double _baseHealth;
        private double _additionalHealth;
        private double _basePower;
        private double _baseMoney;
        private double _additionalMoney;
        private IList<IHeroItem<Armor>> _clothes;
        private IList<IHeroItem<Weapon>> _weapons;


        public Hero(double baseHealth, double basePower, double baseMoney)
        {
            this._baseHealth = baseHealth;
            this._baseMoney = baseMoney;
            this._basePower = basePower;
            this._clothes = new List<IHeroItem<Armor>>();
            this._weapons = new List<IHeroItem<Weapon>>();
        }

        public double Power
        {
            get
            {
                return this._basePower + this._weapons.Sum(x => x.StateBonus);
            }
        }

        public double Health
        {
            get
            {
                return this._baseHealth + this._additionalHealth + this._clothes.Sum(x => x.StateBonus);
            }
        }

        public double Money
        {
            get
            {
                return this._baseMoney + this._additionalMoney;
            }
        }

        //TODO: change to config
        public void Attack()
        {
            var randomHelper = IoC.Instance.Resolve<IRandomHelper>();
            var probability = Math.Min(40 + this.Power * 5, 70)/100.0;
            var isSuccess = randomHelper.IsSuccess(probability);
            if (isSuccess)
            {
                this._additionalHealth -= (0.1 * this.Health);
                this._additionalMoney += 5;
            }
            else
            {
                this._additionalHealth -= (0.4 * this.Health);
            }
        }

        //TODO: change to config
        //TODO: check if enough money
        public void BuyWeapon()
        {
            var weapon = IoC.Instance.Resolve<IHeroItem<Weapon>>();
            if(this.mo)
            this._weapons.Add(weapon);
            this._additionalMoney -= weapon.Cost;
        }
    }
}
