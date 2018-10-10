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
            HeroList.Add(new MiddenheimChampion());
            HeroList.Add(new MiddenheimYoungBlood());

            HenchMenList.Add(new MiddenheimWarrior());
            HenchMenList.Add(new MiddenheimMarksmen());
            HenchMenList.Add(new MiddenheimSwordmen());

            RacialAdvantages = new MiddenheimAdvantage();
        }

        public override int MaximumNumberOfWarriors { get; } = 15;
    }
}