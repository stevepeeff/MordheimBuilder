using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimYoungBlood : YoungBlood
    {
        public override IWarrior GetANewInstance()
        {
            return new MiddenheimYoungBlood();
        }
    }
}