using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public interface IHeroItem<T> where T : class
    {
        int Cost { get; }
        int StateBonus { get; }
    }
}
