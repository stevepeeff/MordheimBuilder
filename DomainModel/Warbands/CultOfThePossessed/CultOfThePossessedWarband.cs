﻿using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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