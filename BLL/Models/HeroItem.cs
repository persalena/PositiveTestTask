using Autofac;
using BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class HeroItem<T>:IHeroItem<T> where T : class
    {
        private int _stateBonus;
        private int _cost;

        public HeroItem(int minStateBonus, int maxStateBonus, int cost)
        {
            var randomHelper = IoC.Instance.Resolve<IRandomHelper>();
            this._stateBonus = randomHelper.GetRandomInt(minStateBonus, maxStateBonus);
            this._cost = cost;

        }
        public int Cost
        {
            get
            {
                return this._cost;
            }
        }

        public int StateBonus
        {
            get
            {
                return _stateBonus;
            }
        }
    }
}
