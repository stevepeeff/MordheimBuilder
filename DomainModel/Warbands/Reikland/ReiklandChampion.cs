using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandChampion : Champion
    {
        public override IWarrior GetANewInstance()
        {
            return new ReiklandChampion();
        }
    }
}