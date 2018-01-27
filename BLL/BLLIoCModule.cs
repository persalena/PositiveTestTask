using Autofac;
using BLL.Helpers;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public sealed class BllIoCModule : Module
    {
        #region Overridden Methods

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<RandomHelper>().As<IRandomHelper>().SingleInstance();
            builder.RegisterType<Weapon>().As<IHeroItem<Weapon>>().WithParameter("minStateBonus", 1)
                                                        .WithParameter("maxStateBonus", 2)
                                                        .WithParameter("cost", 10);
            builder.RegisterType<Armor>().As<IHeroItem<Armor>>().WithParameter("minStateBonus", 1)
                                                        .WithParameter("maxStateBonus", 2)
                                                        .WithParameter("cost", 10);

        }

        #endregion
    }
}
