using DomainModel.RacialAdvantages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    /// <summary>
    /// Provides everything that a warband has
    /// </summary>
    public interface IWarBand
    {
        /// <summary>
        /// Gets the advantages.
        /// </summary>
        /// <value>
        /// The advantages.
        /// </value>
        IRacialAdvantage RacialAdvantages { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; }

        /// <summary>
        /// Gets the hench men.
        /// </summary>
        /// <value>
        /// The hench men.
        /// </value>
        IReadOnlyCollection<IHenchMen> HenchMen { get; }

        /// <summary>
        /// Gets the heroes.
        /// </summary>
        /// <value>
        /// The heroes.
        /// </value>
        IReadOnlyCollection<IHero> Heroes { get; }

        /// <summary>
        /// Gets the maximum number of warriors.
        /// </summary>
        /// <value>
        /// The maximum number of warriors.
        /// </value>
        int MaximumNumberOfWarriors { get; }

        /// <summary>
        /// Gets the name of the war band.
        /// </summary>
        /// <value>
        /// The name of the war band.
        /// </value>
        string WarBandName { get; }

        /// <summary>
        /// Gets the warrior.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        IWarrior GetWarrior(string typeName);

        /// <summary>
        /// Gets the starting cash.
        /// </summary>
        /// <value>
        /// The starting cash.
        /// </value>
        int StartingCash { get; }

        //TODO Special rules like Reikland Marksen +1 BS
        //A description suffices..
        // because  'Statistic'  can be used to accomplish this.
    }
}