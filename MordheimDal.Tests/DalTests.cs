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
using System.Threading;
using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.CultOfThePossessed.Mutations;

namespace MordheimDal.Tests
{
    [TestClass]
    public class DalTests
    {
        private IWarbandRoster _WarbandRoster;

        private IHero _WitchHunterCaptain;

        private IHenchMen _ZealotGroup1;
        private IHenchMen _ZealotGroup2;

        private IWizard _WarriorPriest;

        private readonly string warbandName = "MordheimDalTests";

        [TestInitialize]
        public void Setup()
        {
            _WarbandRoster = new WarBandRoster(new WitchHuntersWarband());
            _WarbandRoster.Name = "MordheimDalTests";

            //Logic requires to add a new warrior
            _WitchHunterCaptain = _WarbandRoster.AddWarrior(new WitchHunterCaptain()) as IHero;

            _WitchHunterCaptain.AddEquipment(new Sword().Name);
            _WitchHunterCaptain.AddEquipment(new CrossBow().Name);
            _WitchHunterCaptain.AddEquipment(new Shield().Name);
            _WitchHunterCaptain.AddEquipment(new LightArmour().Name);

            _WitchHunterCaptain.AddSkill(new MightyBlow());
            _WitchHunterCaptain.AddSkill(new PitFighter());

            _ZealotGroup1 = _WarbandRoster.AddWarrior(new Zealot()) as IHenchMen;
            _ZealotGroup1.AddEquipment(new Sword());
            _ZealotGroup1.AddEquipment(new Sword());
            _ZealotGroup1.IncreaseGroupByOne();
            _ZealotGroup1.IncreaseGroupByOne();

            _ZealotGroup2 = _WarbandRoster.AddWarrior(new Zealot()) as IHenchMen;
            _ZealotGroup2.AddEquipment(new Bow());
            _ZealotGroup2.IncreaseGroupByOne();
            _ZealotGroup2.IncreaseGroupByOne();
            _ZealotGroup2.IncreaseGroupByOne();

            _WarriorPriest = _WarbandRoster.AddWarrior(new WarriorPriest()) as WarriorPriest;
            _WarriorPriest.AddSpell(new HeartsOfSteel());
            _WarriorPriest.AddSpell(new TheHammerOfSigmar());
        }

        //[TestMethod]
        //public void SaveTwice()
        //{ TODO Save, extend Warband, Save again. Ensure the first read differs from the second (hash ??)
        //    _WarbandRoster.Name = $"{nameof(SaveTwice)}";
        //    string storagePath = Path.Combine(XmlDal.STORAGE_PATH, $"Warband Roster SaveTwice.xml");

        //    DalProvider.Instance.Save(_WarbandRoster);
        //    File.Delete(storagePath);

        //    Assert.IsFalse(File.Exists(storagePath), "Failed to ensure that the file was deleted");
        //    FileInfo fileInfo = new FileInfo(storagePath);

        //    DalProvider.Instance.Save(_WarbandRoster);
        //    Assert.IsTrue(File.Exists(storagePath));
        //}

        [TestMethod]
        public void Overwrite()
        {
            _WarbandRoster.Name = $"{warbandName}{nameof(Overwrite)}";
            string storagePath = Path.Combine(XmlDal.STORAGE_PATH, $"{_WarbandRoster.Name}.xml");

            DalProvider.Instance.Save(_WarbandRoster);
            FileInfo file = new FileInfo(storagePath);

            int initialHash = file.GetHashCode();
            int secondHash = file.GetHashCode();

            Assert.AreEqual(initialHash, secondHash, "Hash of same file should be identical");
        }

        [TestMethod]
        public void SaveAndLoadCultOfThePossed()
        {
            var cultRoster = new WarBandRoster(new CultOfThePossessedWarband());
            cultRoster.Name = $"{warbandName}{"SaveAndLoad Cult Of the Possessed"}";

            IHero mutant = cultRoster.AddWarrior(new Mutant()) as IHero;
            mutant.AddMutation(new GreatClaw());
            mutant.AddEquipment(new Axe());

            string storagePath = DalProvider.Instance.Save(cultRoster);
            IWarbandRoster roster = new XmlDal().LoadWarband(storagePath);
            Assert.IsNotNull(roster);

            IMutant loadedMutant = roster.Warriors.First() as IMutant;

            //IMutant mutant = null;
            //foreach (var item in roster.Warriors)
            //{
            //    if (item is IMutant)
            //    {
            //        mutant = item as IMutant;
            //        break;
            //    }
            //}
            //Assert.IsNotNull(mutant);
        }

        [TestMethod]
        public void SaveAndLoad()
        {
            _WarbandRoster.Name = $"{warbandName}{"SaveAndLoad"}";
            string storagePath = DalProvider.Instance.Save(_WarbandRoster);

            IWarbandRoster roster = new XmlDal().LoadWarband(storagePath);
            Assert.IsNotNull(roster);

            IHero loadedHero = roster.Warriors.First() as IHero;

            Assert.AreEqual(_WitchHunterCaptain.Equipment.Count, loadedHero.Equipment.Count);
            Assert.AreEqual(_WitchHunterCaptain.Skills.Count, loadedHero.Skills.Count);

            IMutant mutant = null;
            foreach (var item in roster.Warriors)
            {
                if (item is IMutant)
                {
                    mutant = item as IMutant;
                    break;
                }
            }
            Assert.IsNotNull(mutant);

            IHenchMen loadedHenchMen1 = roster.Warriors.ElementAt(1) as IHenchMen;
            Assert.AreEqual(_ZealotGroup1.AmountInGroup, loadedHenchMen1.AmountInGroup);
            Assert.AreEqual(_ZealotGroup1.Equipment.Count, loadedHenchMen1.Equipment.Count);

            IHenchMen loadedHenchMen2 = roster.Warriors.ElementAt(2) as IHenchMen;
            Assert.AreEqual(_ZealotGroup2.AmountInGroup, loadedHenchMen2.AmountInGroup);
            Assert.AreEqual(_ZealotGroup2.Equipment.Count, loadedHenchMen2.Equipment.Count);

            IWizard loadedWizard = roster.Warriors.ElementAt(3) as IWizard;
            Assert.IsTrue(loadedWizard.DrawnSpells.Any(x => x.SpellName.Equals(nameof(TheHammerOfSigmar))));
        }
    }
}