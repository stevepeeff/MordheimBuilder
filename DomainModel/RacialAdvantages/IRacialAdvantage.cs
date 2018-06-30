using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RacialAdvantages
{
    public interface IRacialAdvantage
    {
        IReadOnlyCollection<Statistic> Statistics { get; }

        string Description { get; }
    }
}