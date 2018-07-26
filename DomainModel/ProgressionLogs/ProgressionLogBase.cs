using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ProgressionLogs
{
    public abstract class ProgressionLogBase : IProgressionLog
    {
        public TimeLog When { get; private set; }

        public string Reason { get; set; }
    }
}