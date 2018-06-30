using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Strength
{
    internal class Resilient : StrengthBase
    {
        public Resilient()
        {
            //_Statistics.Add(new Statistic(Characteristics.Strength, 1, Applications.CloseCombatExcludingPistols));
        }

        public override string Description { get; } = "Deduct -1 Strength from all hits against him in close combat.This does not affect armour save modifiers.";
    }
}