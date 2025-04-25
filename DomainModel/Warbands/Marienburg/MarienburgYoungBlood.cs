using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgYoungBlood : YoungBlood
    {
        public override IWarrior GetANewInstance()
        {
            return new MarienburgYoungBlood();
        }
    }
}