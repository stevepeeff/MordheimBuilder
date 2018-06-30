using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RacialAdvantages
{
    public class ReiklandAdvantage : RacialAdvantagesBase
    {
        public ReiklandAdvantage()
        {
            _Statistics.Add(new Statistic(Characteristics.Strength, 1));
        }

        public override string Description { get; } = "All heroes have a increased Strength";
    }
}