using DomainModel.Magic;
using DomainModel.Psychology;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.SistersOfSigmar
{
    public class SisterSuperior : HeroBase, IHero, IWizard
    {
        public SisterSuperior()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 4;
            BallisticSkill.BaseValue = 4;
            Strength.BaseValue = 3;
            Toughness.BaseValue = 3;
            Wounds.BaseValue = 1;
            Initiative.BaseValue = 4;
            Attacks.BaseValue = 1;
            LeaderShip.BaseValue = 8;

            // _AllowedWeapons.AddRange(UndeadWarband.UndeadEquipmentList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SistersOfSigmarSpecialSkills);

            AddAffliction(new Leader());
        }

        public override int HireFee => 70;

        public override int MaximumAllowedInWarBand => 1;

        public IReadOnlyList<ISpell> SpellList { get; }

        public override IWarrior GetANewInstance()
        {
            return new SisterSuperior();
        }
    }
}