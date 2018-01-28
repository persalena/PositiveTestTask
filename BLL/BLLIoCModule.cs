using Autofac;
using BLL.Helpers;
using BLL.Models;

namespace BLL
{
    public sealed class BllIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var settingsHelper = IoC.Instance.Resolve<ISettingsHelper>();

            builder.RegisterType<KeyListener>().As<IKeyListener>().SingleInstance();

            builder.RegisterType<RandomHelper>().As<IRandomHelper>().SingleInstance();

            builder.RegisterType<DisplayResultHelper>().As<IDisplayResultHelper>();

            builder.RegisterType<Weapon>().As<IHeroItem<Weapon>>().WithParameter("minStateBonus", settingsHelper.Settings.Weapon.MinPoints)
                                                        .WithParameter("maxStateBonus", settingsHelper.Settings.Weapon.MaxPoints)
                                                        .WithParameter("cost", settingsHelper.Settings.Weapon.Cost);

            builder.RegisterType<Armor>().As<IHeroItem<Armor>>().WithParameter("minStateBonus", settingsHelper.Settings.Armor.MinPoints)
                                                        .WithParameter("maxStateBonus", settingsHelper.Settings.Armor.MaxPoints)
                                                        .WithParameter("cost", settingsHelper.Settings.Armor.Cost);

            builder.RegisterType<Healing>().As<IHeroItem<Healing>>().WithParameter("minStateBonus", settingsHelper.Settings.HealthRecover.MinPoints)
                                                        .WithParameter("maxStateBonus", settingsHelper.Settings.HealthRecover.MaxPoints)
                                                        .WithParameter("cost", settingsHelper.Settings.HealthRecover.Cost);

            builder.RegisterType<Hero>().As<IHero>().WithParameter("baseHealth", settingsHelper.Settings.HeroBaseStats.Health)
                                                        .WithParameter("baseMaxHealth", settingsHelper.Settings.HeroBaseStats.MaxHealth)
                                                        .WithParameter("basePower", settingsHelper.Settings.HeroBaseStats.Power)
                                                        .WithParameter("baseMoney", settingsHelper.Settings.HeroBaseStats.Money);

        }
    }
}
