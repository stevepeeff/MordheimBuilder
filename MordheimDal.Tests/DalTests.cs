using System;
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

using System.IO;
using MordheimXmlDal;

namespace MordheimDal.Tests
{
    [TestClass]
    public class DalTests
    {
        private IWarbandRoster _WarbandRoster;

        private IHero _WitchHunterCaptain;

        public DalTests()
        {
            _WarbandRoster = new WarBandRoster(new WitchHuntersWarband());
            _WarbandRoster.Name = "MordheimDal.Tests";

            //Logic requires to add a new warrior
            _WitchHunterCaptain = _WarbandRoster.AddWarrior(new WitchHunterCaptain()) as IHero;

            _WitchHunterCaptain.AddEquipment(new Sword().Name);
            _WitchHunterCaptain.AddEquipment(new CrossBow().Name);
            _WitchHunterCaptain.AddEquipment(new Shield().Name);
            _WitchHunterCaptain.AddEquipment(new LightArmour().Name);

            _WitchHunterCaptain.AddSkill(new MightyBlow());
            _WitchHunterCaptain.AddSkill(new PitFighter());
        }

        [TestMethod]
        public void Save()
        {
            DalProvider.Instance.Save(_WarbandRoster);
        }

        [TestMethod]
        public void SaveAndLoad()
        {
            DalProvider.Instance.Save(_WarbandRoster);
            IWarbandRoster roster = new XmlDal().LoadWarband(Path.Combine(XmlDal.STORAGE_PATH, "Warband Roster MordheimDal.Tests.xml"));
            Assert.IsNotNull(roster);

            //WarBandProvider.Instance.GetWarband("WitchHunters"));
        }
    }
}