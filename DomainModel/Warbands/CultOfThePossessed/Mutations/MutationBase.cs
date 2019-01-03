using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public abstract class MutationBase : IMutation
    {
        protected List<Statistic> _Statistics = new List<Statistic>();

        public abstract int Cost { get; }

        public IReadOnlyCollection<Statistic> Statistics => _Statistics;

        public abstract string Description { get; }

        public string Name => throw new NotImplementedException();
    }
}