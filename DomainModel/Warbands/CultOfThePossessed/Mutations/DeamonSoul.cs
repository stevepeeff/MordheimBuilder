using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class DeamonSoul : IMutation
    {
        private List<Statistic> _Statistics = new List<Statistic>();

        public DeamonSoul()
        {
            _Statistics.Add(new Statistic(Characteristics.Save, 4, Applications.MagicSpellsAndPrayers, Description));
        }

        public int Cost { get; } = 20;

        public string Description { get; } = "A Daemon lives within the mutant’s soul. This gives him a 4+ save against the effects of spells or prayers";

        public IReadOnlyCollection<Statistic> Statistics { get { return _Statistics; } }
    }
}