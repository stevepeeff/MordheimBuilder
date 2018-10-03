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
            HeroList.Add(new SigmariteMatriarch());
            HeroList.Add(new SisterSuperior());
            HeroList.Add(new Augur());

            HenchMenList.Add(new SigmariteSister());
            HenchMenList.Add(new Novice());
        }

        static public List<IEquipment> WeaponList { get; } = new List<IEquipment>()
        {
            new Dagger(), new ClubMaceHammer(), new SigmariteWarhammer(), new Flail(), new SteelWhip(), new DoubleHandedWeapon(),
            new Sling(),
        };

        //TODO add Miscelianes equipment (heroes only)
        static public List<IEquipment> ArmourList { get; } = new List<IEquipment>()
        {
            new LightArmour(), new HeavyArmor(), new Shield(), new Buckler(), new Helmet(),
        };

        public override int MaximumNumberOfWarriors => 15;
    }
}