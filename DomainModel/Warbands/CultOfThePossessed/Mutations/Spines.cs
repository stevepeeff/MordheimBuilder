using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class Spines : IMutation
    {
        private List<Statistic> _Statistics = new List<Statistic>();

        public Spines()
        {
            // _Statistics.Add(new Statistic(Characteristics.Attack, 1, Applications.CloseCombat, Description));
            //  _Statistics.Add(new Statistic(Characteristics.Strength, 1, Applications.CloseCombat, "Only for t attack mad wit tis arm"));
        }

        public int Cost { get; } = 35;

        public string Description { get; } = "Any model in base contact with the mutant suffers an automatic Strength 1 hit at the beginning of each close combat phase.Spines will never cause critical hits.";
        public IReadOnlyCollection<Statistic> Statistics { get { return _Statistics; } }
    }
}