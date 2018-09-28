using System;
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

            Assert.IsFalse(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());
            warrior.AddEquipment(new Sword());
            Assert.IsFalse(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());

            warrior.AddEquipment(new Dagger());
            Assert.IsFalse(warrior.Equipment.HasTwoIdenticalCloseCombatWeapons());

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
        public void IsCarryingHeavyArmorAndShieldFalse()
        {
            var warrior = new WitchHunterCaptain();

            warrior.AddEquipment(new LightArmour());
            warrior.AddEquipment(new Shield());

            Assert.IsFalse(warrior.Equipment.IsCarryingHeavyArmorAndShield());
        }

        [TestMethod]
        public void IsCarryingHeavyArmorAndShieldTrue()
        {
            var warrior = new WitchHunterCaptain();

            warrior.AddEquipment(new Shield());
            warrior.AddEquipment(new HeavyArmor());

            Assert.IsTrue(warrior.Equipment.IsCarryingHeavyArmorAndShield());
        }

        [TestMethod]
        public void MaximumCloseCombatWeaponsReached()
        {
            var warrior = new WitchHunterCaptain();

            ICloseCombatWeapon singleHandenWeapon = new Dagger();
            ICloseCombatWeapon twoHandWeapon = new WeepingBlades();

            Assert.IsFalse(warrior.Equipment.MaximumCloseCombatWeaponsReached());
            warrior.AddEquipment(singleHandenWeapon);
            Assert.IsFalse(warrior.Equipment.MaximumCloseCombatWeaponsReached());

            warrior.AddEquipment(singleHandenWeapon);
            warrior.AddEquipment(singleHandenWeapon);

            Assert.IsTrue(warrior.Equipment.MaximumCloseCombatWeaponsReached());

            warrior.RemoveEquipment(singleHandenWeapon);
            warrior.RemoveEquipment(singleHandenWeapon);
            warrior.RemoveEquipment(singleHandenWeapon);

            Assert.AreEqual(0, warrior.Equipment.Count);

            warrior.AddEquipment(singleHandenWeapon);
            warrior.AddEquipment(twoHandWeapon);

            Assert.IsTrue(warrior.Equipment.MaximumCloseCombatWeaponsReached());

            warrior.RemoveEquipment(singleHandenWeapon);
            Assert.IsTrue(warrior.Equipment.MaximumCloseCombatWeaponsReached(), "Weeping blades is a pair");
        }

        [TestMethod]
        public void WarriorArmour()
        {
            var warrior = new WitchHunterCaptain();
            Assert.AreEqual(0, warrior.Save.CalculatedValue, "No armour should default in 0");

            warrior.AddEquipment(new HeavyArmor());
            Assert.AreEqual(2, warrior.Save.CalculatedValue);
            Assert.IsFalse(warrior.Equipment.IsCarryingHeavyArmorAndShield());

            warrior.AddEquipment(new Shield());
            Assert.IsTrue(warrior.Equipment.IsCarryingHeavyArmorAndShield());
            Assert.AreEqual(3, warrior.Save.CalculatedValue, "Combination of 2 And 1");
        }
    }
}