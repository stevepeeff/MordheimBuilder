using DomainModel.Psychology;
using DomainModel.Skills;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public class Possessed : MutantBase, IHero, IMutant
    {
        public Possessed()
        {
            Movement.BaseValue = 5;
            WeaponSkill.BaseValue = 4;
            BallisticSkill.BaseValue = 0;
            Strength.BaseValue = 4;
            Toughness.BaseValue = 4;
            Wounds.BaseValue = 2;
            Initiative.BaseValue = 4;
            Attacks.BaseValue = 2;
            LeaderShip.BaseValue = 7;

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);

            AddAffliction(new Fear());
        }

        public override int InitialExperience { get; } = 8;

        public override int HireFee => 90;

        public override int MaximumAllowedInWarBand => 2;

        public override IWarrior GetANewInstance()
        {
            return new Possessed();
        }
    }
}