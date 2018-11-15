using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class MutationsProvider
    {
        public IReadOnlyCollection<IMutation> Mutations { get; }

        public static MutationsProvider Instance { get; } = new MutationsProvider();

        private MutationsProvider()
        {
            Mutations = new List<IMutation>()
            {
                new Blackblood(),
                new ClovenHoofs(),
                new DeamonSoul(),
                new ExtraArm(),
                new GreatClaw(),
                new Hideous(),
                new ScorpionTail(),
                new Spines(),
                new Tentacle()
            };
        }
    }
}