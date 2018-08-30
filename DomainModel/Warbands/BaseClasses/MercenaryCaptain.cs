using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class MercenaryCaptain : HumanHeroBase
    {
        public MercenaryCaptain()
        {
            BallisticSkill.BaseValue = 4;
            WeaponSkill.BaseValue = 4;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 8;

            _AllowedSkills.AddRange(SkillProvider.Instance.CombatSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.ShootingSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.AcademicSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.StrengthSkills);
            _AllowedSkills.AddRange(SkillProvider.Instance.SpeedSkills);

            _AllowedWeapons.AddRange(MercenaryEquipmentList);
        }

        public override int HireFee { get; } = 60;

        public override int InitialExperience { get; } = 20;

        public override int MaximumAllowedInWarBand { get; } = 1;

        static internal List<IEquipment> MercenaryEquipmentList { get; } = new List<IEquipment>()
        {
            new Axe(), new Dagger(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new MorningStar(), new Spear(), new Halberd(),
            new CrossBow(), new Pistol(), new BraceOfPistols(), new CrossbowPistol(), new DuellingPistol(), new BraceOfDuellingPistols(), new Bow(),
            new LightArmour(), new HeavyArmor(), new Shield(), new Buckler(), new Helmet(),
        };
    }
}