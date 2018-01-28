using Autofac;
using BLL.Helpers;
using BLL.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class Hero:IHero
    {
        private int _baseHealth;
        private int _baseMaxHealth;
        private int _additionalHealth;
        private int _basePower;
        private int _baseMoney;
        private int _additionalMoney;
        private IList<IHeroItem<Armor>> _armor;
        private IList<IHeroItem<Weapon>> _weapons;


        public Hero(int baseHealth, int baseMaxHealth, int basePower, int baseMoney)
        {
            this._baseHealth = baseHealth;
            this._baseMaxHealth = baseMaxHealth;
            this._baseMoney = baseMoney;
            this._basePower = basePower;
            this._armor = new List<IHeroItem<Armor>>();
            this._weapons = new List<IHeroItem<Weapon>>();
        }

        public int Power
        {
            get
            {
                return this._basePower + this._weapons.Sum(x => x.StateBonus);
            }
        }

        public int Health
        {
            get
            {
                return this._baseHealth + this._additionalHealth;
            }
        }

        public int MaxHealth
        {
            get
            {
                return this._baseMaxHealth +  this._armor.Sum(x => x.StateBonus);
            }
        }

        public int Money
        {
            get
            {
                return this._baseMoney + this._additionalMoney;
            }
        }

        public int WeaponCount
        {
            get
            {
                return this._weapons.Count();
            }
        }

        public int ArmorCount
        {
            get
            {
                return this._armor.Count();
            }
        }

        public ActionResult Attack()
        {
            ActionResult result = null;
            AttackResultCaseConfigModel resultConfig = null;
            var settingsHelper = IoC.Instance.Resolve<ISettingsHelper>();
            var randomHelper = IoC.Instance.Resolve<IRandomHelper>();
            var formulaParams = settingsHelper.Settings.WinPossibility;
            var probability = Math.Min(formulaParams.A + this.Power * formulaParams.B, formulaParams.C) /100.0;
            var isSuccess = randomHelper.IsSuccess(probability);

            double healthLose = 0;
            if (isSuccess)
            {
                resultConfig = settingsHelper.Settings.AttackResult.Win;
                result = new ActionResult(true, Enums.ResultCode.Win);
            }
            else
            {
                resultConfig = settingsHelper.Settings.AttackResult.Lose;
                result = new ActionResult(true, Enums.ResultCode.Loose);
            }

            healthLose = resultConfig.IsPercent
                        ? resultConfig.HealthLose * this.Health / 100.0
                        : resultConfig.HealthLose;

            this._additionalHealth -= (int)Math.Round(healthLose);
            this._additionalMoney += resultConfig.MoneyReceive;

            return result;
            
        }

        public ActionResult BuyWeapon()
        {
            var weapon = IoC.Instance.Resolve<IHeroItem<Weapon>>();
            if (this.Money < weapon.Cost)
            {
                return new ActionResult(false, Enums.ResultCode.NotEnoughMoney);
            }

            this._weapons.Add(weapon);
            this._additionalMoney -= weapon.Cost;

            return new ActionResult(true, Enums.ResultCode.ItemBought);
        }

        public ActionResult BuyArmor()
        {
            var armor = IoC.Instance.Resolve<IHeroItem<Armor>>();
            if (this.Money < armor.Cost)
            {
                return new ActionResult(false, Enums.ResultCode.NotEnoughMoney);
            }

            this._armor.Add(armor);
            this._additionalMoney -= armor.Cost;

            return new ActionResult(true, Enums.ResultCode.ItemBought);
        }

        public ActionResult RestoreHealth()
        {
            var healing = IoC.Instance.Resolve<IHeroItem<Healing>>();
            if (this.Money < healing.Cost)
            {
                return new ActionResult(false, Enums.ResultCode.NotEnoughMoney);
            }

            this._additionalMoney -= healing.Cost;

            if(this.Health + healing.StateBonus > this.MaxHealth)
            {
                this._additionalHealth = this.MaxHealth - this._baseHealth;
            }
            else
            {
                this._additionalHealth += healing.StateBonus;
            }

            return new ActionResult(true, Enums.ResultCode.SuccessHealing);
        }
    }
}
