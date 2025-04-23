using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;
using System.Collections.Generic;

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

        public static List<IEquipment> WeaponList { get; } = new List<IEquipment>()
        {
            new Dagger(), new ClubMaceHammer(), new SigmariteWarhammer(), new Flail(), new SteelWhip(), new DoubleHandedWeapon(),
            new Sling(),
        };

        //TODO add Miscelianes equipment (heroes only)
        public static List<IEquipment> ArmourList { get; } = new List<IEquipment>()
        {
            new LightArmour(), new HeavyArmour(), new Shield(), new Buckler(), new Helmet(),
        };

        public override int MaximumNumberOfWarriors => 15;
    }
}