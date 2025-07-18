﻿using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using System.Collections.Generic;

namespace DomainModel.Warbands.BaseClasses
{
    internal abstract class UndeadHeroBase : HeroBase, IHero
    {
        public UndeadHeroBase()
        {
        }

        protected static List<IEquipment> HeroEquipmentList { get; } = new List<IEquipment>()
        {
            new Dagger(),  new ClubMaceHammer(), new Axe(),  new Sword(),  new DoubleHandedWeapon(),new Spear(), new Halberd(),
            new Bow(), new ShortBow(),
            new LightArmour(),  new HeavyArmour(),   new Shield(), new Helmet(),
        };
    }
}