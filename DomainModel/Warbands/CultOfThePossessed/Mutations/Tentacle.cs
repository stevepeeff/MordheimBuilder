using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class Tentacle : IMutation
    {
        private List<Statistic> _Statistics = new List<Statistic>();

        public Tentacle()
        {
            _Statistics.Add(new Statistic(Characteristics.Attack, -1, Applications.CloseCombat, Description));
        }

        public int Cost { get; } = 35;

        public string Description { get; } =
            "One of the mutant’s arms ends in a tentacle. He may grapple his opponent in close combat to reduce his attacks by -1, down to a minimum of 1. " +
            "The mutant may decide which attack his opponent loses";

        public IReadOnlyCollection<Statistic> Statistics { get { return _Statistics; } }
    }
}