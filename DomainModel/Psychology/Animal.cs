using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class Animal : PsychologyBase
    {
        public override Afflictions Affliction { get; } = Afflictions.NeverGainExperience;

        public override string Description { get; } = "Can't teach a dog a new trick";
    }
}