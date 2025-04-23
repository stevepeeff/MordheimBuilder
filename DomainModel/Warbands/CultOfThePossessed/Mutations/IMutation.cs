using System.Collections.Generic;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public interface IMutation
    {
        int Cost { get; }

        IReadOnlyCollection<Statistic> Statistics { get; }

        string Description { get; }

        string Name { get; }
    }
}