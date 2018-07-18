using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RacialAdvantages
{
    public class MiddenheimAdvantage : RacialAdvantagesBase
    {
        public MiddenheimAdvantage()
        {
            _Statistics.Add(new Statistic(Characteristics.BallisticSkill, 1, Applications.Shooting, $"Middenheim RacialAdvantage : {Description}"));
        }

        public override string Description { get; } = "All marksmen have an increased ballistic skill";
    }
}