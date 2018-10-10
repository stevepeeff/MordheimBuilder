using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class Mutation : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.Mutations;

        public override string Description => "Requires at least 1 mutation at the start of the game";
    }
}