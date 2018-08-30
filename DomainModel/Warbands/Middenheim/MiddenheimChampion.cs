using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimChampion : Champion
    {
        public MiddenheimChampion()
        {
            Advantages = new MiddenheimAdvantage();
        }

        public override IWarrior GetANewInstance()
        {
            return new MiddenheimChampion();
        }
    }
}