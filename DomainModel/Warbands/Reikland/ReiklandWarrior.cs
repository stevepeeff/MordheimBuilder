using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandWarrior : WarriorBase, IHenchMen
    {
        public ReiklandWarrior()
        {
            _AllowedWeapons.AddRange(MercenaryCaptain.MercenaryEquipmentList);
        }

        public override int HireFee => 25;

        public override int MaximumAllowedInWarBand => int.MaxValue;

        public override IWarrior GetANewInstance()
        {
            return new ReiklandWarrior();
        }
    }
}