using DomainModel.Equipment;
using DomainModel.Equipment.Miscellaneous;
using DomainModel.Warbands.SistersOfSigmar;
using DomainModel.Warbands.WitchHunters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainModel.Tests
{
    [TestClass]
    public class AvailabilityTests
    {
        [TestMethod]
        public void Availability()
        {
            Availability availability = new Availability(Availabilities.COMMON);

            availability.AddException(Availabilities.RARE_6, typeof(WarriorPriest));

            foreach (Type item in availability.Exceptions)
            {
                Assert.AreEqual(nameof(WarriorPriest), item.Name.ToString());
            }
        }

        [TestMethod]
        public void BlessedWaterAvailability()
        {
            BlessedWater blessedWater = new BlessedWater();

            Assert.AreEqual(blessedWater.TradeAvailability.AvailabilityRoll, Availabilities.RARE_6);
            //Assert.AreEqual(blessedWater.TradeAvailability.GetException(new WitchHunterCaptain()), Availabilities.COMMON);

            Assert.AreEqual(blessedWater.TradeAvailability.GetException(new Novice()), Availabilities.COMMON);
            Assert.AreEqual(blessedWater.TradeAvailability.GetException(new WarriorPriest()), Availabilities.COMMON);
        }
    }
}