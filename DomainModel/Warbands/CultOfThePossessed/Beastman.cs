using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public class BeastMan : WarriorBase, IHenchMen
    {
        public BeastMan()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 4;
            Toughness.BaseValue = 4;
            Wounds.BaseValue = 2;

            _AllowedWeapons.AddRange(CultOfThePossessedWarband.PossessedEquipmentList);
        }

        public override int HireFee => 45;

        public override int MaximumAllowedInWarBand => 3;

        public override IWarrior GetANewInstance()
        {
            return new BeastMan();
        }
    }
}