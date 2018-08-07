using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Injuries;
using DomainModel.Psychology;
using DomainModel.Skills;
using DomainModel.Skills.Academic;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class WitchHunterCaptain : HumanHeroBase
    {
        public WitchHunterCaptain()
        {
            BallisticSkill.BaseValue = 4;
            WeaponSkill.BaseValue = 4;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 8;

            AddAffliction(new BurnTheWitch());

            _AllowedWeapons.AddRange(WitchHuntersWarband.HeroEquipmentList);

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.ShootingSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);

            //TODO TESTING
            //_Weapons.Add((new Sword()));
            //_Weapons.Add((new CrossBow()));

            //_Skills.Add(SkillProviderTools.StrengthSkills.ElementAt(0));
            //_Skills.Add(SkillProviderTools.StrengthSkills.ElementAt(1));

            //_Weapons.Add((new Shield()));
            //_Weapons.Add((new HeavyArmor()));

            //AddInjury(new NervousCondition());
        }

        public override int InitialExperience { get; } = 20;

        public override int HireFee { get; } = 60;

        public override int MaximumAllowedInWarBand { get; } = 1;

        public override IWarrior GetANewInstance()
        {
            return new WitchHunterCaptain();
        }
    }
}