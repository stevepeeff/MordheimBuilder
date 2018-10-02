using DomainModel.Magic;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    internal class EshinSorcerer : SkavenHeroBase, IWizard
    {
        public EshinSorcerer()
        {
            Movement.BaseValue = 5;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 6;

            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SkavenSpecialSkills);
        }

        public override int HireFee => 45;

        public override int MaximumAllowedInWarBand => 1;

        public override int InitialExperience { get; } = 8;

        public IReadOnlyList<ISpell> SpellList { get; }

        public override IWarrior GetANewInstance()
        {
            return new EshinSorcerer();
        }
    }
}