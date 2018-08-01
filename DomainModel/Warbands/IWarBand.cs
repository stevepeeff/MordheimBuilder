using DomainModel.RacialAdvantages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public interface IWarBand
    {
        IRacialAdvantage Advantages { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; }

        /// <summary>
        /// Gets the name of the war band.
        /// </summary>
        /// <value>
        /// The name of the war band.
        /// </value>
        string WarBandName { get; }

        IWarrior GetWarrior(string typeName);

        /// <summary>
        /// Gets the hench men.
        /// </summary>
        /// <value>
        /// The hench men.
        /// </value>
        IReadOnlyCollection<IHenchMan> HenchMen { get; }

        /// <summary>
        /// Gets the heroes.
        /// </summary>
        /// <value>
        /// The heroes.
        /// </value>
        IReadOnlyCollection<IHero> Heroes { get; }

        int MaximumNumberOfWarriors { get; }

        //TODO Special rules like Reikland Marksen +1 BS
        //A description suffices..
        // because  'Statistic'  can be used to accomplish this.
    }
}