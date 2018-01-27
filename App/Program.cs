using BLL;
using BLL.Helpers;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            IoCConfig.Initialize();
            var keyListener = new KeyListener();
            keyListener.Init();
        }
    }
}
