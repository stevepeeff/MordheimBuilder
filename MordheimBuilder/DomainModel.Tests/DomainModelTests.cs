using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Injuries;
using DomainModel.Skills;
using DomainModel.Skills.Strength;
using DomainModel.Warbands;
using DomainModel.Warbands.BaseClasses;
using DomainModel.Warbands.Middenheim;
using DomainModel.Warbands.Reikland;
using DomainModel.Warbands.Skaven;
using DomainModel.Warbands.WitchHunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainModel.Tests
{
    [TestClass]
    public class DomainModelTests
    {
        [TestMethod]
        public void AssassinAdept()
        {
            var warrior = new AssassinAdept();

            Assert.AreEqual(6, warrior.Movement.BaseValue, "Movement.BaseValue");
            Assert.AreEqual(6, warrior.Movement.MaximumValue, "Movement.MaximumValue");

            Assert.AreEqual(4, warrior.WeaponSkill.CalculatedValue, "WeaponSkill.CalculatedValue");
            Assert.AreEqual(6, warrior.WeaponSkill.MaximumValue, "WeaponSkill.MaximumValue");

            Assert.AreEqual(4, warrior.BallisticSkill.CalculatedValue, "BallisticSkill.CalculatedValue");
            Assert.AreEqual(6, warrior.BallisticSkill.MaximumValue, "BallisticSkill.MaximumValue");

            Assert.AreEqual(4, warrior.Strength.CalculatedValue, "Strength");
            Assert.AreEqual(4, warrior.Strength.MaximumValue, "StrengthMax");

            Assert.AreEqual(3, warrior.Toughness.CalculatedValue, "Toughness.CalculatedValue");
            Assert.AreEqual(4, warrior.Toughness.MaximumValue, "Toughness.MaximumValue");

            Assert.AreEqual(1, warrior.Wounds.CalculatedValue, "Wounds.CalculatedValue");
            Assert.AreEqual(3, warrior.Wounds.MaximumValue, "Wounds.MaximumValue");

            Assert.AreEqual(1, warrior.Attacks.CalculatedValue, "Attack");
            Assert.AreEqual(4, warrior.Attacks.MaximumValue, "AttackMax");

            Assert.AreEqual(5, warrior.Initiative.CalculatedValue, "Initiative");
            Assert.AreEqual(7, warrior.Initiative.MaximumValue, "Initiative.MaximumValue");

            Assert.AreEqual(7, warrior.LeaderShip.BaseValue, "LeaderShip");
            Assert.AreEqual(7, warrior.LeaderShip.MaximumValue, "LeadershipMax");
        }

        [TestMethod]
        public void Flagellant()
        {
            var warrior = new Flagellant();

            Assert.AreEqual(4, warrior.Movement.BaseValue, "Movement.BaseValue");
            Assert.AreEqual(4, warrior.Movement.MaximumValue, "Movement.MaximumValue");

            Assert.AreEqual(3, warrior.WeaponSkill.CalculatedValue, "WeaponSkill.CalculatedValue");
            Assert.AreEqual(4, warrior.WeaponSkill.MaximumValue, "WeaponSkill.MaximumValue");

            Assert.AreEqual(3, warrior.BallisticSkill.CalculatedValue, "BallisticSkill.CalculatedValue");
            Assert.AreEqual(4, warrior.BallisticSkill.MaximumValue, "BallisticSkill.MaximumValue");

            Assert.AreEqual(4, warrior.Strength.CalculatedValue, "Strength");
            Assert.AreEqual(4, warrior.Strength.MaximumValue, "StrengthMax");

            Assert.AreEqual(3, warrior.Toughness.CalculatedValue, "Toughness.CalculatedValue");
            Assert.AreEqual(4, warrior.Toughness.MaximumValue, "Toughness.MaximumValue");

            Assert.AreEqual(1, warrior.Wounds.CalculatedValue, "Wounds.CalculatedValue");
            Assert.AreEqual(2, warrior.Wounds.MaximumValue, "Wounds.MaximumValue");

            Assert.AreEqual(1, warrior.Attacks.CalculatedValue, "Attack");
            Assert.AreEqual(2, warrior.Attacks.MaximumValue, "AttackMax");

            Assert.AreEqual(3, warrior.Initiative.CalculatedValue, "Initiative");
            Assert.AreEqual(4, warrior.Initiative.MaximumValue, "Initiative.MaximumValue");

            Assert.AreEqual(10, warrior.LeaderShip.BaseValue, "LeaderShip");
            Assert.AreEqual(10, warrior.LeaderShip.MaximumValue, "LeadershipMax");
        }

        [TestMethod]
        public void HenchMenLevelUpCalculationMarkers()
        {
            int[] validvalues = new int[]
            {
                2, 5,9,14
            };

            for (int i = 0; i < 90; i++)
            {
                if (i < validvalues.Length)
                {
                    int calculationValue = validvalues.ElementAt(i);
                    Assert.IsTrue(WarriorBase.LevelUpCalculationHenchMan(calculationValue), $"Failed on input {validvalues[i]}");
                }
            }
        }

        [TestMethod]
        public void HeroLevelUpCalculationMarkers()
        {
            int[] validvalues = new int[]
            {
                2, 4, 6, 8,
                11,14,17,20,
                24,28,32,36,
                41,46,51,
                57,63,69,
                76,83,90
            };

            for (int i = 0; i < 90; i++)
            {
                if (i < validvalues.Length)
                {
                    int calculationValue = validvalues.ElementAt(i);
                    Assert.IsTrue(HeroBase.LevelUpCalculationHero(calculationValue), $"Failed on input {validvalues[i]}");
                }
            }
        }

        [TestMethod]
        public void MiddenheimMarksmen()
        {
            var warrior = new ReiklandMarksmen();

            Assert.AreEqual(4, warrior.Movement.BaseValue, "Movement.BaseValue");
            Assert.AreEqual(4, warrior.Movement.MaximumValue, "Movement.MaximumValue");

            Assert.AreEqual(3, warrior.WeaponSkill.CalculatedValue, "WeaponSkill.CalculatedValue");
            Assert.AreEqual(4, warrior.WeaponSkill.MaximumValue, "WeaponSkill.MaximumValue");

            Assert.AreEqual(4, warrior.BallisticSkill.CalculatedValue, "BallisticSkill.CalculatedValue");
            Assert.AreEqual(4, warrior.BallisticSkill.MaximumValue, "BallisticSkill.MaximumValue");

            Assert.AreEqual(3, warrior.Strength.CalculatedValue, "Strength");
            Assert.AreEqual(4, warrior.Strength.MaximumValue, "StrengthMax");

            Assert.AreEqual(3, warrior.Toughness.CalculatedValue, "Toughness.CalculatedValue");
            Assert.AreEqual(4, warrior.Toughness.MaximumValue, "Toughness.MaximumValue");

            Assert.AreEqual(1, warrior.Wounds.CalculatedValue, "Wounds.CalculatedValue");
            Assert.AreEqual(2, warrior.Wounds.MaximumValue, "Wounds.MaximumValue");

            Assert.AreEqual(1, warrior.Attacks.CalculatedValue, "Attack");
            Assert.AreEqual(2, warrior.Attacks.MaximumValue, "AttackMax");

            Assert.AreEqual(3, warrior.Initiative.CalculatedValue, "Initiative");
            Assert.AreEqual(4, warrior.Initiative.MaximumValue, "Initiative.MaximumValue");

            Assert.AreEqual(7, warrior.LeaderShip.BaseValue, "LeaderShip");
            Assert.AreEqual(8, warrior.LeaderShip.MaximumValue, "LeadershipMax");
        }

        /// <summary>
        /// WitchHunterCaptain as all skills
        /// Therefore perfect for test purposes
        /// </summary>
        [TestMethod]
        public void Skills()
        {
            IHero withchHunterCaptain = new WitchHunterCaptain();
            IReadOnlyCollection<ISkill> skills = withchHunterCaptain.AllowedSkills;

            Assert.AreEqual(3, SkillProvider.Instance.StrengthSkills.Count(), "This test will fail when all skills are added");
        }

        [TestMethod]
        public void WitchHunterCaptain()
        {
            //SkillProvider.Instance.Start();
            var warrior = new WitchHunterCaptain();

            Assert.AreEqual(4, warrior.Movement.BaseValue, "Movement.BaseValue");
            Assert.AreEqual(4, warrior.Movement.MaximumValue, "Movement.MaximumValue");

            Assert.AreEqual(4, warrior.WeaponSkill.CalculatedValue, "WeaponSkill.CalculatedValue");
            Assert.AreEqual(6, warrior.WeaponSkill.MaximumValue, "WeaponSkill.MaximumValue");

            Assert.AreEqual(4, warrior.BallisticSkill.CalculatedValue, "BallisticSkill.CalculatedValue");
            Assert.AreEqual(6, warrior.BallisticSkill.MaximumValue, "BallisticSkill.MaximumValue");

            Assert.AreEqual(3, warrior.Strength.CalculatedValue, "Strength");
            Assert.AreEqual(4, warrior.Strength.MaximumValue, "StrengthMax");

            Assert.AreEqual(3, warrior.Toughness.CalculatedValue, "Toughness.CalculatedValue");
            Assert.AreEqual(4, warrior.Toughness.MaximumValue, "Toughness.MaximumValue");

            Assert.AreEqual(1, warrior.Wounds.CalculatedValue, "Wounds.CalculatedValue");
            Assert.AreEqual(3, warrior.Wounds.MaximumValue, "Wounds.MaximumValue");

            Assert.AreEqual(1, warrior.Attacks.CalculatedValue, "Attack");
            Assert.AreEqual(4, warrior.Attacks.MaximumValue, "AttackMax");

            Assert.AreEqual(4, warrior.Initiative.CalculatedValue, "Initiative");
            Assert.AreEqual(6, warrior.Initiative.MaximumValue, "Initiative.MaximumValue");

            Assert.AreEqual(8, warrior.LeaderShip.BaseValue, "LeaderShip");
            Assert.AreEqual(9, warrior.LeaderShip.MaximumValue, "LeadershipMax");
        }

        [TestMethod]
        public void WitchHunterCaptainInjury()
        {
            var warrior = new WitchHunterCaptain();

            warrior.AddInjury(new NervousCondition());

            Assert.AreEqual(3, warrior.Initiative.CalculatedValue, "Initiative");
        }

        [TestMethod]
        public void WitchHunterCaptainWithSkillMightyBlow()
        {
            var warrior = new WitchHunterCaptain();

            warrior.AddSkill(new MightyBlow());

            Assert.AreEqual(4, warrior.Strength.CalculatedValue, "Strength");

            Assert.AreEqual("MightyBlow", warrior.Skills.ElementAt(0).SkillName());

            Assert.AreEqual(warrior.Skills.ElementAt(0).Description,
                "The warrior knows how to use his strength to maximum effect and has a +1 Strength bonus in close combat.");
        }
    }
}