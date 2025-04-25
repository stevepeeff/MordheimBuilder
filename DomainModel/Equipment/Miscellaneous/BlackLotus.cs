using System;

namespace DomainModel.Equipment.Miscellaneous
{
    public class BlackLotus : EquipmentBase
    {
        public override int Cost => throw new NotImplementedException();

        public override Usage Duration => Usage.ONE_BATTLE;

        public override string Description =>
            "Automatically wound on a roll of 6. " + Environment.NewLine +
            "Note that you still need to roll check if a 'Critical Hit' is scored.";
    }
}