using System.Collections.Generic;

namespace DomainModel.Injuries
{
    internal class ArmWound
    {
        public int From { get; } = 11;

        public int Till { get; } = 15;

        public string Description { get; } = "Remove From Roster";

        public ArmWound()
        {
            Details.Add(new Detail(1, "Lose an arm (1 single handed weapon)", Durations.Permanent, null));
            Details.Add(new Detail(2, 6, "Warrior misses the next game", Durations.OneGame, null));
        }

        private IList<Detail> Details = new List<Detail>();
    }
}