﻿using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;
using System.Collections.Generic;

namespace DomainModel.Warbands.Undead
{
    public class UndeadWarband : WarbandBase
    {
        public UndeadWarband()
        {
            HeroList.Add(new Vampire());
            HeroList.Add(new Necromancer());
            HeroList.Add(new Dreg());

            HenchMenList.Add(new Zombie());
            HenchMenList.Add(new Ghoul());
            HenchMenList.Add(new DireWolf());
        }

        public static List<IEquipment> UndeadEquipmentList { get; } = new List<IEquipment>()
        {
             new Dagger(), new Axe(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(), new Spear(), new Halberd(),
            new Bow(), new ShortBow(),
            new LightArmour(), new HeavyArmour(), new Shield(), new Helmet(),
        };

        public override int MaximumNumberOfWarriors => 15;
    }
}