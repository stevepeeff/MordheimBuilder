using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using System.Collections.Generic;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class Marksmen : WarriorBase, IHenchMen
    {
        public Marksmen()
        {
            Movement.MaximumValue = 4;

            _AllowedWeapons = new List<IEquipment>()
            {
            new Axe(), new Dagger(), new ClubMaceHammer(), new Sword(),
            new CrossBow(), new Pistol(), new BraceOfPistols(), new CrossBow(), new Bow(), new LongBow(), new Blunderbuss(), new HandGun(), new HochlanLongRifle(),
            new LightArmour(), new Shield(),  new Helmet()
            };
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = 7;
    }
}