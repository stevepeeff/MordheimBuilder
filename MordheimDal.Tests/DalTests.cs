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
using DomainModel.Magic.Prayers_of_Sigmar;

namespace MordheimDal.Tests
{
    [TestClass]
    public class DalTests
    {
        private IWarbandRoster _WarbandRoster;

        private IHero _WitchHunterCaptain;

        private IHenchMan _ZealotGroup1;
        private IHenchMan _ZealotGroup2;

        private IWizard _WarriorPriest;

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

            _ZealotGroup1 = _WarbandRoster.AddWarrior(new Zealot()) as IHenchMan;
            _ZealotGroup1.AddEquipment(new Sword());
            _ZealotGroup1.AddEquipment(new Sword());
            _ZealotGroup1.IncreaseGroupByOne();
            _ZealotGroup1.IncreaseGroupByOne();

            _ZealotGroup2 = _WarbandRoster.AddWarrior(new Zealot()) as IHenchMan;
            _ZealotGroup2.AddEquipment(new Bow());
            _ZealotGroup2.IncreaseGroupByOne();
            _ZealotGroup2.IncreaseGroupByOne();
            _ZealotGroup2.IncreaseGroupByOne();

            _WarriorPriest = _WarbandRoster.AddWarrior(new WarriorPriest()) as WarriorPriest;
            _WarriorPriest.SpellList.Add(new TheHammerOfSigmar());
            // _WarriorPriest.add
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

            IHero loadedHero = roster.Warriors.First() as IHero;

            Assert.AreEqual(_WitchHunterCaptain.Equipment.Count, loadedHero.Equipment.Count);
            Assert.AreEqual(_WitchHunterCaptain.Skills.Count, loadedHero.Skills.Count);

            IHenchMan loadedHenchMen1 = roster.Warriors.ElementAt(1) as IHenchMan;
            Assert.AreEqual(_ZealotGroup1.AmountInGroup, loadedHenchMen1.AmountInGroup);
            Assert.AreEqual(_ZealotGroup1.Equipment.Count, loadedHenchMen1.Equipment.Count);

            IHenchMan loadedHenchMen2 = roster.Warriors.ElementAt(2) as IHenchMan;
            Assert.AreEqual(_ZealotGroup2.AmountInGroup, loadedHenchMen2.AmountInGroup);
            Assert.AreEqual(_ZealotGroup2.Equipment.Count, loadedHenchMen2.Equipment.Count);
        }
    }
}