using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using System.Collections.Generic;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class SkavenHeroBase : HeroBase, IHero
    {
        public SkavenHeroBase()
        {
            Movement.BaseValue = 6;

            Movement.MaximumValue = 6;
            WeaponSkill.MaximumValue = 6;
            BallisticSkill.MaximumValue = 6;
            Strength.MaximumValue = 4;
            Toughness.MaximumValue = 4;
            Wounds.MaximumValue = 3;
            Initiative.MaximumValue = 7;
            Attacks.MaximumValue = 4;
            LeaderShip.MaximumValue = 7;

            _AllowedWeapons.AddRange(HeroEquipmentList);
        }

        protected static List<IEquipment> HeroEquipmentList { get; } = new List<IEquipment>()
        {
            new Dagger(), new Sword(), new Flail(), new Spear(), new Halberd(), new WeepingBlades(), new FightingClaws(),
            new Sling(), new ThrowingStarKnive(), new BlowPipe(), new WarplockPistol(),
            new LightArmour(),  new Buckler(), new Helmet(),
        };
    }
}