using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Strength
{
    public class MightyBlow : StrengthBase
    {
        public MightyBlow()
        {
            _Statistics.Add(new Statistic(Characteristics.Strength, 1, Applications.CloseCombatExcludingPistols, $"Skill, MightyBlow: {Description}"));
        }

        public override string Description { get; } = "The warrior knows how to use his strength to maximum effect and has a +1 Strength bonus in close combat.";
    }
}