using System.Collections.Generic;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public abstract class MutationBase : IMutation
    {
        protected List<Statistic> _Statistics = new List<Statistic>();

        public abstract int Cost { get; }

        public IReadOnlyCollection<Statistic> Statistics => _Statistics;

        public abstract string Description { get; }

        public string Name => this.GetType().Name;
    }
}