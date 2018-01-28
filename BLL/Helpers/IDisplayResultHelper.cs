using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public interface IDisplayResultHelper
    {
        void ShowResult(ActionResult actionResult, IHero hero);
    }
}
