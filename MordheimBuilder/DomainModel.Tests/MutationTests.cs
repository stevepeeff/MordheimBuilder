using System;
using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.CultOfThePossessed.Mutations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainModel.Tests
{
    [TestClass]
    public class MutationTests
    {
        [TestMethod]
        public void ExtraArmMutation()
        {
            Mutant warrior = new Mutant();

            Assert.AreEqual(2, warrior.MaximumCloseCombatWeapons);

            warrior.AddMutation(new GreatClaw());

            warrior.AddMutation(new ExtraArm());
            warrior.AddMutation(new ExtraArm());// Ensuring each mutation can be added only once

            Assert.AreEqual(3, warrior.MaximumCloseCombatWeapons);
        }

        [TestMethod]
        public void MutationCosts()
        {
            Mutant warrior = new Mutant();

            Assert.AreEqual(0, warrior.EquipmentCosts);

            warrior.AddMutation(new GreatClaw());

            Assert.AreNotEqual(0, warrior.EquipmentCosts);
        }

        [TestMethod]
        public void CountNumberOfMutations()
        {
            Assert.AreEqual(9, MutationsProvider.Instance.Mutations.Count);
        }

        [TestMethod]
        public void GreatClawMutation()
        {
            Mutant warrior = new Mutant();

            Assert.AreEqual(1, warrior.Attacks.CalculatedValue);
            Assert.AreEqual(3, warrior.Strength.CalculatedValue);

            warrior.AddMutation(new GreatClaw());

            Assert.AreEqual(2, warrior.Attacks.CalculatedValue);
            Assert.AreEqual(4, warrior.Strength.CalculatedValue);
        }
    }
}