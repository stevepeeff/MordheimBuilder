using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class ClovenHoofs : IMutation
    {
        private List<Statistic> _Statistics = new List<Statistic>();

        public ClovenHoofs()
        {
            _Statistics.Add(new Statistic(Characteristics.Movement, 1, Applications.Permenant, Description));
        }

        public int Cost { get; } = 40;

        public string Description { get; } = "The warrior gains +1 Movement";

        public IReadOnlyCollection<Statistic> Statistics { get { return _Statistics; } }
    }
}