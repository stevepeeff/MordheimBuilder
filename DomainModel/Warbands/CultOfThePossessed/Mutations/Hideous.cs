using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class Hideous : IMutation
    {
        public Hideous()
        {
        }

        public int Cost { get; } = 40;

        public string Description { get; } = "The mutant causes fears";

        public IReadOnlyCollection<Statistic> Statistics { get; } = new List<Statistic>();
    }
}