using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Settings
{
    public class AttackResultCaseConfigModel
    {
        public int HealthLose { set; get; }
        public int MoneyReceive { set; get; }
        public bool IsPercent { set; get; }
    }
}
