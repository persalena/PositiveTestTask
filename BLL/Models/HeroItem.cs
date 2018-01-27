using Autofac;
using BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class HeroItem<T>:IHeroItem<T> where T : class
    {
        private double _stateBonus;
        private double _cost;

        public HeroItem(double minStateBonus, double maxStateBonus, double cost)
        {
            var randomHelper = IoC.Instance.Resolve<IRandomHelper>();
            this._stateBonus = randomHelper.GetRandomDouble(minStateBonus, maxStateBonus);
            this._cost = cost;

        }
        public double Cost
        {
            get
            {
                return this._cost;
            }
        }

        public double StateBonus
        {
            get
            {
                return _stateBonus;
            }
        }
    }
}
