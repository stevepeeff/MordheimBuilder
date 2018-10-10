using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgWarband : WarbandBase
    {
        public MarienburgWarband()
        {
            HeroList.Add(new MarienburgMercenaryCaptain());
            HeroList.Add(new MarienburgChampion());
            HeroList.Add(new MarienburgYoungBlood());

            HenchMenList.Add(new MarienburgWarrior());
            HenchMenList.Add(new MarienburgMarksmen());
            HenchMenList.Add(new MarienburgSwordmen());

            RacialAdvantages = new MarienburgAdvantage();
        }

        public override int MaximumNumberOfWarriors { get; } = 15;
    }
}