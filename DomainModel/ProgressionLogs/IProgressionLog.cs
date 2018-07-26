using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ProgressionLogs
{
    public interface IProgressionLog
    {
        TimeLog When { get; }

        string Reason { get; }
    }
}