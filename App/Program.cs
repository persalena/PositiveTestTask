using Autofac;
using BLL;
using BLL.Helpers;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.Initialize(new SettingsIoCModule());
            IoC.Instance.Resolve<ISettingsHelper>().Initialize();
            IoC.Update(new BllIoCModule());

            var keyListener = new KeyListener();
            keyListener.Init();
        }
    }
}
