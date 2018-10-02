using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class ImmuneToPsychology : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.ImmuneToPsychology;

        public override string Description => "Vampires are not affected by psychology(such as fear) and never leave combat.";
    }
}