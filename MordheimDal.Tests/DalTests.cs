using System;
using System.Collections.Generic;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MordheimDal.Tests
{
    [TestClass]
    public class DalTests
    {
        [TestMethod]
        public void Load()
        {
            string warriorName = "DomainModel.Warbands.WitchHunters.WitchHunterCaptain";

            WitchHunterWarband witchHunters = new WitchHunterWarband();
            WitchHunterCaptain witchHunterCaptain = new WitchHunterCaptain();

            List<IWarBand> warbands = new List<IWarBand>();
            warbands.Add(new WitchHunterWarband());

            Assert.IsNotNull(warbands.First(x => x.WarBandName.Equals("WitchHunters")));

            List<IHero> heroes = new List<IHero>();
            heroes.AddRange(witchHunters.Heroes);

            //  witchHunters.Heroes;

            string name = witchHunterCaptain.ToString();

            witchHunterCaptain.AddEquipment(new Sword());
            witchHunterCaptain.AddEquipment(new CrossBow());
            witchHunterCaptain.AddEquipment(new Shield());
            witchHunterCaptain.AddEquipment(new LightArmour());

            //_Skills.Add(SkillProvider.StrengthSkills.ElementAt(0));
            //_Skills.Add(SkillProvider.StrengthSkills.ElementAt(1));
        }
    }
}