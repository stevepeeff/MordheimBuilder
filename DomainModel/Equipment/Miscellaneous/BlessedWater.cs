using DomainModel.Warbands.WitchHunters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Miscellaneous
{
    public class BlessedWater : EquipmentBase
    {
        public BlessedWater()
        {
            VariableCost = new VariabeleCosts(6, 3);
        }

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_6, typeof(WitchHuntersWarband));

        public override int Cost => 10;

        public override Availabilities Availability { get; } = Availabilities.RARE_6;

        public override Usage Duration => Usage.ONE_USE;

        public override string Description =>
            "Blessed water causes 1 wound on Undead, Daemon or Possessed models automatically. There is no armour save." + Environment.NewLine +
            "Has a thrown range of twice the thrower’s Strength in inches." + Environment.NewLine +
            "Roll to hit using the model’s BS.No modifiers for range or moving apply." + Environment.NewLine +
            "Undead or Possessed models may not use blessed water.";
    }
}