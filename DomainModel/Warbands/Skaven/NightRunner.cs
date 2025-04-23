using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Skaven
{
    internal class NightRunner : SkavenHeroBase
    {
        public NightRunner()
        {
            WeaponSkill.BaseValue = 2;
            LeaderShip.BaseValue = 4;
            Initiative.BaseValue = 4;

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.ShootingSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SkavenSpecialSkills);
        }

        public override int HireFee => 20;

        public override int MaximumAllowedInWarBand => 2;

        public override IWarrior GetANewInstance()
        {
            return new NightRunner();
        }
    }
}