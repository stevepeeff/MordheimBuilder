using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgWarrior : WarriorBase, IHenchMen
    {
        public MarienburgWarrior()
        {
            _AllowedWeapons.AddRange(MercenaryCaptain.MercenaryEquipmentList);
        }

        public override int HireFee => 25;

        public override int MaximumAllowedInWarBand => int.MaxValue;

        public override IWarrior GetANewInstance()
        {
            return new MarienburgWarrior();
        }
    }
}