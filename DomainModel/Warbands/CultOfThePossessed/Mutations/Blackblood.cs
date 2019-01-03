using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class Blackblood : MutationBase
    {
        public Blackblood()
        {
        }

        public override int Cost { get; } = 30;

        public override string Description { get; } = "If the model loses a wound in close combat, anyone in base contact with the model suffers a Strength 3 hit (no critical hits) from the spurting corrosive blood.";
    }
}