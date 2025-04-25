using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimWarrior : WarriorBase, IHenchMen
    {
        public MiddenheimWarrior()
        {
            _AllowedWeapons.AddRange(MercenaryCaptain.MercenaryEquipmentList);
        }

        public override int HireFee => 25;

        public override int MaximumAllowedInWarBand => int.MaxValue;

        public override IWarrior GetANewInstance()
        {
            return new MiddenheimWarrior();
        }
    }
}