using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Settings
{
    public class AttackResultConfigModel
    {
        public AttackResultCaseConfigModel Win { set; get; }
        public AttackResultCaseConfigModel Lose { set; get; }
    }
}
