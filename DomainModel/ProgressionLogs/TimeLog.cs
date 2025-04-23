using System;

namespace DomainModel.ProgressionLogs
{
    public class TimeLog
    {
        public DateTime When { get; private set; } = DateTime.Now;

        public BattleInformation Scenario { get; private set; }
    }
}