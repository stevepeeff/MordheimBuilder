using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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