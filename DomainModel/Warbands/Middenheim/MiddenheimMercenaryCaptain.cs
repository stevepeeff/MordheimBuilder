using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;

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