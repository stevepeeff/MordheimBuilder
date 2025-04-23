using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgMercenaryCaptain : MercenaryCaptain
    {
        public override IWarrior GetANewInstance()
        {
            return new MarienburgMercenaryCaptain();
        }
    }
}