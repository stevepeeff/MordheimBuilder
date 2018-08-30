using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimMercenaryCaptain : MercenaryCaptain
    {
        public MiddenheimMercenaryCaptain()
        {
            Advantages = new MiddenheimAdvantage();
        }

        public override IWarrior GetANewInstance()
        {
            return new MiddenheimMercenaryCaptain();
        }
    }
}