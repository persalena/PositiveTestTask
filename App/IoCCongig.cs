using BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class IoCConfig
    {
        public static void Initialize()
        {
            IoC.Initialize(
                new BllIoCModule()
            );
        }
    }
}
