using System;
using System.Collections.Generic;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MordheimBuilderLogic;
using DomainModel.Skills;
using DomainModel.Skills.Strength;

namespace MordheimDal.Tests
{
    [TestClass]
    public class DalTests
    {
        private WitchHunterCaptain _WitchHunterCaptain;

        public DalTests()
        {
            BuilderLogicFactory.Instance.SelectWarBand(new WitchHuntersWarband());

            _WitchHunterCaptain = new WitchHunterCaptain();

            _WitchHunterCaptain.AddEquipment(new Sword().Name);
            _WitchHunterCaptain.AddEquipment(new CrossBow().Name);
            _WitchHunterCaptain.AddEquipment(new Shield().Name);
            _WitchHunterCaptain.AddEquipment(new LightArmour().Name);

            _WitchHunterCaptain.AddSkill(new MightyBlow());
            _WitchHunterCaptain.AddSkill(new PitFighter());

            BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(_WitchHunterCaptain);

            //        _ExampleWarband = new WitchHuntersWarband();
            //_ExampleWarband.a
            //WitchHunterCaptain witchHunterCaptain = new WitchHunterCaptain();
        }

        [TestMethod]
        public void Save()
        {
            Assert.IsNotNull(BuilderLogicFactory.Instance.CurrentWarband);

            BuilderLogicFactory.Instance.SaveWarband();
        }

        [TestMethod]
        public void Load()
        {
            Assert.IsNotNull(BuilderLogicFactory.Instance.CurrentWarband);
            //WarBandProvider.Instance.GetWarband("WitchHunters"));

            ;
        }
    }
}