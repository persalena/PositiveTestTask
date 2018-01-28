using Autofac;
using BLL.Helpers;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public sealed class SettingsIoCModule : Module
    {
        #region Overridden Methods

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<SettingsHelper>().As<ISettingsHelper>().SingleInstance();
        }

        #endregion
    }
}
