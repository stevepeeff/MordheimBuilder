using DomainModel.Magic;
using DomainModel.Psychology;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System.Collections.Generic;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public class Magister : HeroBase, IHero, IWizard
    {
        public Magister()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 4;
            BallisticSkill.BaseValue = 4;
            Strength.BaseValue = 3;
            Toughness.BaseValue = 3;
            Wounds.BaseValue = 1;
            Initiative.BaseValue = 3;
            Attacks.BaseValue = 1;
            LeaderShip.BaseValue = 8;

            _AllowedWeapons.AddRange(CultOfThePossessedWarband.PossessedEquipmentList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);

            AddAffliction(new Leader());
        }

        public override int InitialExperience { get; } = 20;
        public override int HireFee => 70;

        public override int MaximumAllowedInWarBand => 1;

        public IReadOnlyList<ISpell> SpellList { get; }

        public override IWarrior GetANewInstance()
        {
            return new Magister();
        }
    }
}