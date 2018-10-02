using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class NoPain : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.ImmunToPain;

        public override string Description => "Treat 'Stunned' as 'Knocked down'";
    }
}