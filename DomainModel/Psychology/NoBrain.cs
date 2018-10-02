using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class NoBrain : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.NeverGainExperience;

        public override string Description => "They do not learn from their mistakes.What did you expect?";
    }
}