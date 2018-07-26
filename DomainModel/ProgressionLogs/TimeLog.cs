using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ProgressionLogs
{
    public class TimeLog
    {
        public DateTime When { get; private set; } = DateTime.Now;

        public BattleInformation Scenario { get; private set; }
    }
}