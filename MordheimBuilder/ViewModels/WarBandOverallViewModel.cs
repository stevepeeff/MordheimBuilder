using DomainModel;
using DomainModel.Warbands;
using MordheimBuilder.Commands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimBuilder.ViewModels
{
    public class WarBandOverallViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WarBandOverallViewModel"/> class.
        /// </summary>
        public WarBandOverallViewModel()
        {
            Warbands = new List<WarBandOverallViewModel>();
            foreach (var item in BuilderLogicFactory.Instance.AvailableWarbands)
            {
                Warbands.Add(new WarBandOverallViewModel(item));
            }
        }

        public IProperViewToViewModel ViewInterface { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WarBandOverallViewModel"/> class.
        /// </summary>
        /// <param name="warband">The warband.</param>
        private WarBandOverallViewModel(IWarBand warband)
        {
            Warband = warband;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description => Warband.Description;

        public int MaximumWarriorOfNumbers => Warband.MaximumNumberOfWarriors;

        /// <summary>
        /// Gets the maximum warriors.
        /// </summary>
        /// <value>
        /// The maximum warriors.
        /// </value>
        public int MaximumWarriors => Warband.MaximumNumberOfWarriors;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => Warband.WarBandName;

        /// <summary>
        /// Gets or sets the selected warband.
        /// </summary>
        /// <value>
        /// The selected warband.
        /// </value>
        public WarBandOverallViewModel SelectedWarband { get; set; }

        /// <summary>
        /// Gets the select warband command.
        /// </summary>
        /// <value>
        /// The select warband command.
        /// </value>
        public ICommand SelectWarbandCommand => new SelectWarband(this);

        /// <summary>
        /// Gets the starting cash.
        /// </summary>
        /// <value>
        /// The starting cash.
        /// </value>
        public int StartingCash => Warband.StartingCash;

        /// <summary>
        /// Gets the warband.
        /// </summary>
        /// <value>
        /// The warband.
        /// </value>
        public IWarBand Warband { get; }

        /// <summary>
        /// Gets the warbands.
        /// </summary>
        /// <value>
        /// The warbands.
        /// </value>
        public IList<WarBandOverallViewModel> Warbands { get; }
    }
}