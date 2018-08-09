using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Speed
{
    public class SpeedBase : SkillBase, ISpeed
    {
        public override string SkillTypeName { get; } = "Speed";

        public override string Description { get; } = "Not defined";
    }
}