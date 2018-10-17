using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RacialAdvantages
{
    public class MiddenheimAdvantage : AdvantagesBase
    {
        public MiddenheimAdvantage()
        {
            _Statistics.Add(new Statistic(Characteristics.Strength, 1, $"Middenheim Racial Advantage : {Description}"));
        }

        public override string Description { get; } = "Captain and Champions have a increased Strength";
    }
}