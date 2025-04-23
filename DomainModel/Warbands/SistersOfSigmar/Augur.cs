using DomainModel.Psychology;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.SistersOfSigmar
{
    public class Augur : HeroBase, IHero, ISistersOfSigmar
    {
        public Augur()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;
            Strength.BaseValue = 3;
            Toughness.BaseValue = 3;
            Wounds.BaseValue = 1;
            Initiative.BaseValue = 3;
            Attacks.BaseValue = 1;
            LeaderShip.BaseValue = 7;

            _AllowedWeapons.AddRange(SistersOfSigmarWarband.WeaponList);

            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SistersOfSigmarSpecialSkills);

            AddAffliction(new BlessedSight());
        }

        public override int HireFee => 25;

        public override int MaximumAllowedInWarBand => 1;

        public override IWarrior GetANewInstance()
        {
            return new Augur();
        }
    }
}