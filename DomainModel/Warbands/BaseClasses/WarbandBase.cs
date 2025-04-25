using DomainModel.RacialAdvantages;
using System;
using System.Collections.Generic;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class WarbandBase : IWarBand
    {
        public abstract int MaximumNumberOfWarriors { get; }

        protected List<IHero> HeroList = new List<IHero>();

        protected List<IHenchMen> HenchMenList = new List<IHenchMen>();

        public IReadOnlyCollection<IHero> Heroes
        { get { return HeroList; } }

        public IReadOnlyCollection<IHenchMen> HenchMen
        { get { return HenchMenList; } }

        public IWarrior GetWarrior(string typeName)
        {
            foreach (IHero hero in Heroes)
            {
                if (hero.TypeName.Equals(typeName))
                {
                    return hero;
                }
            }
            foreach (IHenchMen henchMen in HenchMen)
            {
                if (henchMen.TypeName.Equals(typeName))
                {
                    return henchMen;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the advantages
        /// </summary>
        /// <value>
        /// The advantages (if applicable)
        /// </value>
        public IRacialAdvantage RacialAdvantages { get; protected set; } = null;

        public string Description { get; } = "TODO";

        public int StartingCash => CalculateStartgCash();

        public static readonly int DefaultStartingCash = 500;

        private int CalculateStartgCash()
        {
            int startingAmount = DefaultStartingCash;
            double multiplier = 1.0;

            if (RacialAdvantages != null)
            {
                foreach (var item in RacialAdvantages.Statistics)
                {
                    if (item.Characteristic == Characteristics.Wealth)
                    {
                        multiplier += (item.AppliedValue / 100.0);
                    }
                }
            }
            return (int)(startingAmount * multiplier);
        }

        //if Characteristics.Wealth, 20, Applications.WarbandStartIncome, increase

        public string WarBandName
        { get { return this.GetType().Name.Replace("Warband", String.Empty); } }
    }
}