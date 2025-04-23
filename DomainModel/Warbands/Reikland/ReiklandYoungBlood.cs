using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandYoungBlood : YoungBlood
    {
        public override IWarrior GetANewInstance()
        {
            return new ReiklandYoungBlood();
        }
    }
}