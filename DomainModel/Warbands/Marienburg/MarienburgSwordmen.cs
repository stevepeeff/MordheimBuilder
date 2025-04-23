using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgSwordmen : Swordmen
    {
        public override IWarrior GetANewInstance()
        {
            return new MarienburgSwordmen();
        }
    }
}