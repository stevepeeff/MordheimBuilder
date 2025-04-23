using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;

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