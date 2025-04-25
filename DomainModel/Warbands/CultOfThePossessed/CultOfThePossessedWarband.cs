using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;
using System.Collections.Generic;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public class CultOfThePossessedWarband : WarbandBase
    {
        public CultOfThePossessedWarband()
        {
            HeroList.Add(new Magister());
            HeroList.Add(new Possessed());
            HeroList.Add(new Mutant());

            HenchMenList.Add(new DarkSoul());
            HenchMenList.Add(new Brethren());
            HenchMenList.Add(new BeastMan());
        }

        public override int MaximumNumberOfWarriors { get; } = 15;

        public static List<IEquipment> DarkSoulsEquipmentList { get; } = new List<IEquipment>()
        {
            new Dagger(), new Axe(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new Spear(),
            new LightArmour(), new HeavyArmour(), new Shield(), new Helmet(),
        };

        //Todo proper way use DarkSouls Equipment and  Missle Weapons??
        public static List<IEquipment> PossessedEquipmentList { get; } = new List<IEquipment>()
        {
            new Dagger(), new Axe(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new Spear(),
            new Bow(), new ShortBow(),
            new LightArmour(), new HeavyArmour(), new Shield(), new Helmet(),
        };
    }
}