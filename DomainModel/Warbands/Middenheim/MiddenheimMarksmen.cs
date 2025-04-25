using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimMarksmen : Marksmen
    {
        public override IWarrior GetANewInstance()
        {
            return new MiddenheimMarksmen();
        }
    }
}