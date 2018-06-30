using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RacialAdvantages
{
    public abstract class RacialAdvantagesBase : IRacialAdvantage
    {
        protected List<Statistic> _Statistics = new List<Statistic>();
        public IReadOnlyCollection<Statistic> Statistics { get { return _Statistics; } }

        public abstract string Description { get; }
    }
}