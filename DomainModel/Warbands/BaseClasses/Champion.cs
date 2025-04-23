using DomainModel.Skills;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class Champion : HumanHeroBase
    {
        public Champion()
        {
            WeaponSkill.BaseValue = 4;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 7;

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.ShootingSkills);

            _AllowedWeapons.AddRange(MercenaryCaptain.MercenaryEquipmentList);
        }

        public override int HireFee { get; } = 35;

        public override int InitialExperience { get; } = 8;

        public override int MaximumAllowedInWarBand { get; } = 2;
    }
}