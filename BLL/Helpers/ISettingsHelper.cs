using BLL.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public interface ISettingsHelper
    {
        SettingsModel Settings { get; }
        void Initialize();
    }
}
