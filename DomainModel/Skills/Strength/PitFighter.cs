using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Strength
{
    public class PitFighter : StrengthBase
    {
        public PitFighter()
        {
            _Statistics.Add(new Statistic(Characteristics.Attack, 1, Applications.InsideBuildings));
            _Statistics.Add(new Statistic(Characteristics.WeaponSkill, 1, Applications.InsideBuildings));
        }

        public override string Description { get; } = "The warrior is an expert at fighting in confined areas and adds +1 to his WS and +1 to his Attacks if he is fighting inside buildings or ruins.";
    }
}