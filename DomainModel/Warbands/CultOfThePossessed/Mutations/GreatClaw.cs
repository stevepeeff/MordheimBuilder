using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class GreatClaw : IMutation
    {
        private List<Statistic> _Statistics = new List<Statistic>();

        public GreatClaw()
        {
            _Statistics.Add(new Statistic(Characteristics.Attack, 1, Applications.CloseCombat, Description));
            _Statistics.Add(new Statistic(Characteristics.Strength, 1, Applications.CloseCombat, "Only for t attack mad wit tis arm"));
        }

        public int Cost { get; } = 50;

        public string Description { get; } = "The mutant has an extra arm, giving him +1 attack and Strnt bonus";
        public IReadOnlyCollection<Statistic> Statistics { get { return _Statistics; } }
    }
}