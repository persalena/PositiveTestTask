using BLL.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using System;
using System.Collections.Generic;
using System.IO;

namespace BLL.Helpers
{
    public class SettingsHelper:ISettingsHelper
    {
        private SettingsModel _settings { set; get; }

        public SettingsModel Settings
        {
            get
            {
                return _settings;
            }
        }

        public void Initialize()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", true, true)
                   .Build();

                var settings = new SettingsModel
                {
                    HeroBaseStats = config.GetSection("HeroBaseStats").Get<HeroBaseStatsConfigModel>(),
                    WinPossibility = config.GetSection("WinPossibility").Get<WinPossibilityConfigModel>(),
                    AttackResult = new AttackResultConfigModel
                    {
                        Win = config.GetSection("AttackResult").GetSection("Win").Get<AttackResultCaseConfigModel>(),
                        Lose = config.GetSection("AttackResult").GetSection("Lose").Get<AttackResultCaseConfigModel>()
                    },
                    Weapon = config.GetSection("Weapon").Get<HeroItemConfigModel>(),
                    Armor = config.GetSection("Armor").Get<HeroItemConfigModel>(),
                    HealthRecover = config.GetSection("HealthRecover").Get<HeroItemConfigModel>()
                };
                this._settings = settings;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
