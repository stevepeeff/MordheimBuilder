using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands.WitchHunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainModel.Tests
{
    [TestClass]
    public class EquipmentToolsTests
    {
        [TestMethod]
        public void HasTwoIdenticalCloseCombatWeapons()
        {
            var warrior = new WitchHunterCaptain();
            var dagger = new Dagger();

            Assert.IsFalse(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());
            warrior.AddEquipment(new Sword());
            Assert.IsFalse(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());

            warrior.AddEquipment(dagger);
            Assert.IsFalse(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());

            warrior.RemoveEquipment(dagger);
            warrior.AddEquipment(new Sword());
            Assert.IsTrue(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());
        }

        [TestMethod]
        public void HasTwoIdenticalCloseCombatWeaponsPair()
        {
            var warrior = new WitchHunterCaptain();

            Assert.IsFalse(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());
            warrior.AddEquipment(new WeepingBlades());
            Assert.IsTrue(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());
        }

        [TestMethod]
        public void HasHeavyArmorAndShieldFalse()
        {
            var warrior = new WitchHunterCaptain();

            warrior.AddEquipment(new LightArmour());
            warrior.AddEquipment(new Shield());

            Assert.IsFalse(warrior.Equipment.HasHeavyArmorAndShield());
        }

        [TestMethod]
        public void HasHeavyArmorAndShieldTrue()
        {
            var warrior = new WitchHunterCaptain();

            warrior.AddEquipment(new Shield());
            warrior.AddEquipment(new HeavyArmour());

            Assert.IsTrue(warrior.Equipment.HasHeavyArmorAndShield());
        }

        [TestMethod]
        public void MaximumCloseCombatWeaponsReached()
        {
            var warrior = new WitchHunterCaptain();

            ICloseCombatWeapon singleHandenWeapon = new Dagger();
            ICloseCombatWeapon twoHandWeapon = new WeepingBlades();

            Assert.IsFalse(warrior.MaximumCloseCombatWeaponsReached());
            warrior.AddEquipment(singleHandenWeapon);
            Assert.IsFalse(warrior.MaximumCloseCombatWeaponsReached());

            warrior.AddEquipment(singleHandenWeapon);
            warrior.AddEquipment(singleHandenWeapon);

            Assert.IsTrue(warrior.MaximumCloseCombatWeaponsReached());

            warrior.RemoveEquipment(singleHandenWeapon);
            warrior.RemoveEquipment(singleHandenWeapon);
            warrior.RemoveEquipment(singleHandenWeapon);

            Assert.AreEqual(0, warrior.Equipment.Count);

            warrior.AddEquipment(singleHandenWeapon);
            warrior.AddEquipment(twoHandWeapon);

            Assert.IsTrue(warrior.MaximumCloseCombatWeaponsReached());

            warrior.RemoveEquipment(singleHandenWeapon);
            Assert.IsTrue(warrior.MaximumCloseCombatWeaponsReached(), "Weeping blades is a pair");
        }

        [TestMethod]
        public void WarriorArmourAndShield()
        {
            var warrior = new WitchHunterCaptain();
            Assert.AreEqual(0, warrior.Save.CalculatedValue, "No armour should default in 0");

            warrior.AddEquipment(new HeavyArmour());
            Assert.AreEqual(2, warrior.Save.CalculatedValue);
            Assert.IsFalse(warrior.Equipment.HasHeavyArmorAndShield());

            warrior.AddEquipment(new Shield());
            Assert.IsTrue(warrior.Equipment.HasHeavyArmorAndShield());
            Assert.AreEqual(3, warrior.Save.CalculatedValue, "Combination of 2 And 1");
        }
    }
}