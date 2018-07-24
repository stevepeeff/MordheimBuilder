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

namespace MordheimDal.Tests
{
    [TestClass]
    public class DalTests
    {
        private IWarBand _ExampleWarband;
        private WitchHunterCaptain _WitchHunterCaptain;

        public DalTests()
        {
            BuilderLogicFactory.Instance.SelectWarBand(new WitchHuntersWarband());

            _WitchHunterCaptain = new WitchHunterCaptain();

            _WitchHunterCaptain.AddEquipment(new Sword());
            _WitchHunterCaptain.AddEquipment(new CrossBow());
            _WitchHunterCaptain.AddEquipment(new Shield());
            _WitchHunterCaptain.AddEquipment(new LightArmour());

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

            //_Skills.Add(SkillProvider.StrengthSkills.ElementAt(0));
            //_Skills.Add(SkillProvider.StrengthSkills.ElementAt(1));
        }
    }
}