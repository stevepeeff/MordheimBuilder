using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandSwordmen : Swordmen
    {
        public override IWarrior GetANewInstance()
        {
            return new ReiklandSwordmen();
        }
    }
}