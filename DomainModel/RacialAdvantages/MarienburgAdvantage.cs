using System;

namespace DomainModel.RacialAdvantages
{
    public class MarienburgAdvantage : AdvantagesBase
    {
        public MarienburgAdvantage()
        {
            _Statistics.Add(new Statistic(Characteristics.Wealth, 20, Applications.WarbandStartIncome, $" Marienburg Racial Advantage;{Description}"));
        }

        public override string Description { get; } =
            "Increased wealth starts the game with 20% more gold crowns. " + Environment.NewLine +
            "Marienburg war-bands receive a +1 bonus when attempting to find rare items (Trading).";
    }
}