using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    /// <summary>
    /// Henchmen are bought and maintained in groups
    /// </summary>
    /// <seealso cref="DomainModel.Warbands.IWarrior" />
    public interface IHenchMan : IWarrior
    {
        /// <summary>
        /// Gets the amount in group.
        /// </summary>
        /// <value>
        /// The amount in group.
        /// </value>
        int AmountInGroup { get; }

        /// <summary>
        /// Gets the group costs.
        /// </summary>
        /// <value>
        /// The group costs.
        /// </value>
        int? GroupCosts { get; }

        /// <summary>
        /// Increases the group by one.
        /// </summary>
        void IncreaseGroupByOne();

        /// <summary>
        /// Decreases the group by one.
        /// </summary>
        void DecreaseGroupByOne();
    }
}