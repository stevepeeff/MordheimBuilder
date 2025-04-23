using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgChampion : Champion
    {
        public override IWarrior GetANewInstance()
        {
            return new MarienburgChampion();
        }
    }
}