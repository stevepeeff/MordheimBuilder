﻿using System;
using System.Collections.Generic;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using DomainModel.Skills;
using DomainModel.Skills.Strength;
using DomainModel;
using MordheimBuilderLogic;

namespace MordheimDal.Tests
{
    [TestClass]
    public class DalTests
    {
        private IWarbandRoster _WarbandRoster;

        private IWarBand _WarBand = null;
        private WitchHunterCaptain _WitchHunterCaptain;

        public DalTests()
        {
            _WarbandRoster = new WarBandRoster(new WitchHuntersWarband());
            _WarbandRoster.Name = "MordheimDal.Tests";
            _WitchHunterCaptain = new WitchHunterCaptain();

            _WitchHunterCaptain.AddEquipment(new Sword().Name);
            _WitchHunterCaptain.AddEquipment(new CrossBow().Name);
            _WitchHunterCaptain.AddEquipment(new Shield().Name);
            _WitchHunterCaptain.AddEquipment(new LightArmour().Name);

            _WitchHunterCaptain.AddSkill(new MightyBlow());
            _WitchHunterCaptain.AddSkill(new PitFighter());

            //  BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(_WitchHunterCaptain);

            //        _ExampleWarband = new WitchHuntersWarband();
            //_ExampleWarband.a
            //WitchHunterCaptain witchHunterCaptain = new WitchHunterCaptain();
        }

        [TestMethod]
        public void Save()
        {
            Assert.IsNotNull(_WarBand);

            DalProvider.Instance.Save(_WarbandRoster);
        }

        [TestMethod]
        public void Load()
        {
            IWarBand warBand = DalProvider.Instance.Load();
            Assert.IsNotNull(warBand);
            //WarBandProvider.Instance.GetWarband("WitchHunters"));

            ;
        }
    }
}