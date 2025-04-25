using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimSwordmen : Swordmen
    {
        public override IWarrior GetANewInstance()
        {
            return new MiddenheimSwordmen();
        }
    }
}