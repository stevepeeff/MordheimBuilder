using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class Fear : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.Fear;

        public override string Description => "Causes Fear";
    }
}