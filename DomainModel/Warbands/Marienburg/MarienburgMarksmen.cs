using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgMarksmen : Marksmen
    {
        public override IWarrior GetANewInstance()
        {
            return new MarienburgMarksmen();
        }
    }
}