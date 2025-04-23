using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public class Brethren : WarriorBase, IHenchMen
    {
        public Brethren()
        {
            _AllowedWeapons.AddRange(CultOfThePossessedWarband.PossessedEquipmentList);
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = INFINITE;

        public override IWarrior GetANewInstance()
        {
            return new Brethren();
        }
    }
}