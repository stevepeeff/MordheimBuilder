using System.Collections.Generic;

namespace DomainModel.RacialAdvantages
{
    public abstract class AdvantagesBase : IRacialAdvantage
    {
        protected List<Statistic> _Statistics = new List<Statistic>();

        public IReadOnlyCollection<Statistic> Statistics
        { get { return _Statistics; } }

        public abstract string Description { get; }
    }
}