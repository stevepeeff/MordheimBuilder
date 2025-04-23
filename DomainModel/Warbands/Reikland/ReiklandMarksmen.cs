using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandMarksmen : Marksmen
    {
        public ReiklandMarksmen()
        {
            Advantages = new ReiklandAdvantage();
        }

        public override IWarrior GetANewInstance()
        {
            return new ReiklandMarksmen();
        }
    }
}