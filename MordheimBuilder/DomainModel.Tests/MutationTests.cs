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
    }
}