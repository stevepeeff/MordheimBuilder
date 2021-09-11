using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class BurnTheWitch : PsychologyBase
    {
        public override Afflictions Affliction { get; } = Afflictions.Hate;

        public override string Description { get; } = "All models who can cast spells";
    }
}