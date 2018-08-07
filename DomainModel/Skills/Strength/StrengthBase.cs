using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Strength
{
    public class StrengthBase : SkillBase, IStrength
    {
        public override string Name { get; } = "Strength";

        public override string Description { get; } = "Not defined";
    }
}