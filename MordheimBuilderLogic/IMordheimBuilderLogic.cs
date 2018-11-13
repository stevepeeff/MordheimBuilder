using DomainModel;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilderLogic
{
    public enum Modus
    {
        Play,
        Edit
    }

    /// <summary>
    /// Logic for Selecting a Warband and providing the roster
    /// </summary>
    public interface IMordheimBuilderLogic
    {
        /// <summary>
        /// Gets the available warbands.
        /// </summary>
        /// <value>
        /// The available warbands.
        /// </value>
        IReadOnlyCollection<IWarBand> AvailableWarbands { get; }

        /// <summary>
        /// Selects the war band.
        /// </summary>
        /// <param name="warband">The warband.</param>
        void SelectWarBand(IWarBand warband);

        /// <summary>
        /// Selects the war band.
        /// </summary>
        /// <param name="warbandName">Name of the warband.</param>
        void SelectWarBand(string warbandName);

        /// <summary>
        /// Gets the current warband.
        /// </summary>
        /// <value>
        /// The current warband.
        /// </value>
        IWarBand CurrentWarband { get; }

        /// <summary>
        /// Gets the warband roster.
        /// </summary>
        /// <value>
        /// The warband roster.
        /// </value>
        IWarbandRoster WarbandRoster { get; }

        /// <summary>
        /// Occurs when [play modus changes].
        /// </summary>
        event EventHandler PlayModusChanges;

        /// <summary>
        /// Gets the starting cash.
        /// </summary>
        /// <value>
        /// The starting cash.
        /// </value>
        int StartingCash { get; }

        /// <summary>
        /// Gets or sets the play modus.
        /// </summary>
        /// <value>
        /// The play modus.
        /// </value>
        Modus PlayModus { get; set; }
    }
}