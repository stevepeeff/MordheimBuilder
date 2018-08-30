using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimWarband : WarbandBase
    {
        public MiddenheimWarband()
        {
            HeroList.Add(new MiddenheimMercenaryCaptain());

            HenchMenList.Add(new MiddenheimMarksmen());

            Advantages = new MiddenheimAdvantage();
        }

        public override int MaximumNumberOfWarriors { get; } = 15;
    }
}