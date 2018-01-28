using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public interface IRandomHelper
    {
        double GetRandomDouble(double min, double max);
        int GetRandomInt(int min, int max);
        bool IsSuccess(double probability);
    }
}
