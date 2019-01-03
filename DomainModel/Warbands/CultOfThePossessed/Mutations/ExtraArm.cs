using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class ExtraArm : MutationBase
    {
        public ExtraArm()
        {
            _Statistics.Add(new Statistic(Characteristics.Attack, 1, Applications.CloseCombat, Description));
        }

        public override int Cost { get; } = 40;

        public override string Description { get; } = "The mutant has an extra arm, giving him +1 attack when fighting in hand-to-hand combat (may add 1 equipment)";
    }
}