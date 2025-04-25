using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandWarband : WarbandBase
    {
        public ReiklandWarband()
        {
            HeroList.Add(new ReiklandMercenaryCaptain());
            HeroList.Add(new ReiklandChampion());
            HeroList.Add(new ReiklandYoungBlood());

            HenchMenList.Add(new ReiklandWarrior());
            HenchMenList.Add(new ReiklandMarksmen());
            HenchMenList.Add(new ReiklandSwordmen());

            RacialAdvantages = new ReiklandWarbandAdvantage();
        }

        public override int MaximumNumberOfWarriors => 15;
    }
}