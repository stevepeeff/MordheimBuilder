using System.Collections.Generic;

namespace DomainModel.RacialAdvantages
{
    public interface IRacialAdvantage
    {
        IReadOnlyCollection<Statistic> Statistics { get; }

        string Description { get; }
    }
}