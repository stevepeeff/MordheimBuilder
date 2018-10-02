using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.SistersOfSigmar
{
    public class SistersOfSigmarWarband : WarbandBase
    {
        public SistersOfSigmarWarband()
        {
            HeroList.Add(new SisterSuperior());
            //HeroList.Add(new SigmariteMatriarch());
            //HeroList.Add(new Augur());

            //HenchMenList.Add(new SigmariteSister());
            //HenchMenList.Add(new Novice());
        }

        static public List<IEquipment> WeaponList { get; } = new List<IEquipment>()
        {
             new Dagger(), new Axe(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new Spear(), new Halberd(),
            new Bow(), new ShortBow(),
            new LightArmour(), new HeavyArmor(), new Shield(), new Helmet(),
        };

        static public List<IEquipment> ArmourList { get; } = new List<IEquipment>()
        {
             new Dagger(), new Axe(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new Spear(), new Halberd(),
            new Bow(), new ShortBow(),
            new LightArmour(), new HeavyArmor(), new Shield(), new Helmet(),
        };

        public override int MaximumNumberOfWarriors => 15;
    }
}