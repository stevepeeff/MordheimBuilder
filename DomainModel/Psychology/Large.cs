using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class Large : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.LargeTarget;

        public override string Description => "A bulking huge target (or big enemy, depending on you point of view ;) A large creature increases the warband rating with 20 )";
    }
}