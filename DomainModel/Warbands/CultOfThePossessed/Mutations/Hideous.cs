using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class Hideous : MutationBase
    {
        public Hideous()
        {
        }

        public override int Cost { get; } = 40;

        public override string Description { get; } = "The mutant causes fears";
    }
}