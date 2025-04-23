using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Undead
{
    internal class Ghoul : WarriorBase, IHenchMen
    {
        public Ghoul()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;
            Strength.BaseValue = 3;
            Toughness.BaseValue = 4;
            Wounds.BaseValue = 1;
            Initiative.BaseValue = 3;
            Attacks.BaseValue = 2;
            LeaderShip.BaseValue = 5;

            AddAffliction(new Fear());
        }

        public override int HireFee => 40;

        public override int MaximumAllowedInWarBand => INFINITE;

        public override IWarrior GetANewInstance()
        {
            return new Ghoul();
        }
    }
}