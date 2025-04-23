using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandMercenaryCaptain : MercenaryCaptain
    {
        public override IWarrior GetANewInstance()
        {
            return new ReiklandMercenaryCaptain();
        }
    }
}