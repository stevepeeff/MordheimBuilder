using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Combat
{
    public class CombatBase : SkillBase, ICombat
    {
        public override string Name { get; } = "Combat";

        public override string Description { get; } = "Not defined";
    }
}