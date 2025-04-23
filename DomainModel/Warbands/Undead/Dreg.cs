using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Undead
{
    internal class Dreg : UndeadHeroBase
    {
        public Dreg()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;
            //Strength.BaseValue = 4;
            //Toughness.BaseValue = 4;
            //Wounds.BaseValue = 2;
            Initiative.BaseValue = 3;
            // Attacks.BaseValue = 3;
            LeaderShip.BaseValue = 7;

            _AllowedWeapons.AddRange(UndeadWarband.UndeadEquipmentList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
        }

        public override int HireFee => 20;

        public override int MaximumAllowedInWarBand => 3;

        public override IWarrior GetANewInstance()
        {
            return new Dreg();
        }
    }
}