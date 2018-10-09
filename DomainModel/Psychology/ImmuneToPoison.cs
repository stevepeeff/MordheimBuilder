using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class ImmuneToPoison : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.ImmuneToPoison;

        public override string Description => "No affected by any poison.";
    }
}