using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public class DarkSoul : WarriorBase, IHenchMen
    {
        public DarkSoul()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;
            Strength.BaseValue = 4;
            LeaderShip.BaseValue = 6;

            _AllowedWeapons.AddRange(CultOfThePossessedWarband.PossessedEquipmentList);
            AddAffliction(new Crazed());
        }

        public override int HireFee => 35;

        public override int MaximumAllowedInWarBand => 5;

        public override IWarrior GetANewInstance()
        {
            return new DarkSoul();
        }
    }
}