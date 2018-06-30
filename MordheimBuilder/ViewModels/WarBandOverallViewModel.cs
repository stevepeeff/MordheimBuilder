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
        private IWarbandRoster m_WarbandRoster;

        public WarBandOverallViewModel()
        {
            ShowNewWarBandCommand = new ShowNewWarBand(this);
            m_WarbandRoster = BuilderLogicFactory.Instance.WarbandRoster;
            m_WarbandRoster.WarBandChanged += Instance_WarBandChanged;
        }

        public string Description
        {
            get { return "BROKEN"; }
        }

        public string MaximumWarriorOfNumbers
        {
            get { return "BROKEN"; }
        }

        public string Name
        {
            get { return "Broken"; }
        }

        public string Perks
        {
            get
            {
                return "BROKEN";
                //if (_WarBand.Advantages == null)
                //{
                //    return "N/A";
                //}

                //return _WarBand.Advantages.Description;
            }
        }

        /// <summary>
        /// Gets or sets the selected warband.
        /// </summary>
        /// <value>
        /// The selected warband.
        /// </value>
        public WarBandOverallViewModel SelectedWarband { get; set; }

        /// <summary>
        /// Gets the show new war band command.
        /// </summary>
        /// <value>
        /// The show new war band command.
        /// </value>
        public ICommand ShowNewWarBandCommand { get; private set; }

        public int TotalCosts
        {
            get
            {
                return m_WarbandRoster.TotalCosts;
            }
        }

        public int WarbandRating
        {
            get
            {
                return m_WarbandRoster.WarbandRating;
            }
        }

        /// <summary>
        /// Gets the warrior count summary.
        /// </summary>
        /// <value>
        /// The warrior count summary.
        /// </value>
        public string WarriorCountSummary
        {
            get
            {
                return $"{m_WarbandRoster.TotalNumberOfWarriors} (out of {m_WarbandRoster.WarBand.MaximumNumberOfWarriors})";
            }
        }

        private void Instance_WarBandChanged(object sender, EventArgs e)
        {
            UpdateAllProperties();
        }

        private void UpdateAllProperties()
        {
            RaisePropertyChangedEvent(nameof(TotalCosts));
            RaisePropertyChangedEvent(nameof(WarriorCountSummary));
            RaisePropertyChangedEvent(nameof(WarbandRating));
            RaisePropertyChangedEvent(nameof(Name));
            RaisePropertyChangedEvent(nameof(MaximumWarriorOfNumbers));
            RaisePropertyChangedEvent(nameof(Description));
        }
    }
}