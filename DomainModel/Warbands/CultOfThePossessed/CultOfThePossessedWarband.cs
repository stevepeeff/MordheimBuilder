using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed
{
    internal class CultOfThePossessedWarband
    {
        static public List<IEquipment> DarkSoulsEquipmentList { get; } = new List<IEquipment>()
        {
            new Dagger(), new Axe(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new Spear(),
            new LightArmour(), new HeavyArmor(), new Shield(), new Helmet(),
        };

        //Todo proper way use DarkSouls Equipment and  Missle Weapons??
        static public List<IEquipment> PossessedEquipmentList { get; } = new List<IEquipment>()
        {
            new Dagger(), new Axe(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new Spear(),
            new Bow(), new ShortBow(),
            new LightArmour(), new HeavyArmor(), new Shield(), new Helmet(),
        };
    }
}