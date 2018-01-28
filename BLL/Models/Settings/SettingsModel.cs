using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Settings
{
    public class SettingsModel
    {
        public HeroBaseStatsConfigModel HeroBaseStats { set; get; }

        public WinPossibilityConfigModel WinPossibility { set; get; }

        public AttackResultConfigModel AttackResult { set; get; }

        public HeroItemConfigModel Weapon { set; get; }

        public HeroItemConfigModel Armor { set; get; }

        public HeroItemConfigModel HealthRecover { set; get; }
    }
}
