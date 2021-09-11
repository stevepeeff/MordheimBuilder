using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class ClovenHoofs : MutationBase
    {
        public ClovenHoofs()
        {
            _Statistics.Add(new Statistic(Characteristics.Movement, 1, Applications.Permenant, Description));
        }

        public override int Cost { get; } = 40;

        public override string Description { get; } = "The warrior gains +1 Movement";
    }
}