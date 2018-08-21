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
        private IWarBand m_Warband;

        public WarBandOverallViewModel()
        {
            Warbands = new List<WarBandOverallViewModel>();
            foreach (var item in BuilderLogicFactory.Instance.AvailableWarbands)
            {
                Warbands.Add(new WarBandOverallViewModel(item));
            }
        }

        private WarBandOverallViewModel(IWarBand warband)
        {
            m_Warband = warband;
        }

        public string Description
        {
            get { return "BROKEN"; }
        }

        public int MaximumWarriorOfNumbers => m_Warband.MaximumNumberOfWarriors;

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

        public int StartingCash => 100;

        /// <summary>
        /// Gets the warbands.
        /// </summary>
        /// <value>
        /// The warbands.
        /// </value>
        public IList<WarBandOverallViewModel> Warbands { get; }

        //public int TotalCosts
        //{
        //    get
        //    {
        //        return m_Warband.;
        //    }
        //}

        //public int WarbandRating
        //{
        //    get
        //    {
        //        return m_Warband.WarbandRating;
        //    }
        //}

        /// <summary>
        ///// Gets the warrior count summary.
        ///// </summary>
        ///// <value>
        ///// The warrior count summary.
        ///// </value>
        //public string WarriorCountSummary
        //{
        //    get
        //    {
        //        return $"{m_Warband.TotalNumberOfWarriors} (out of {m_Warband.WarBand.MaximumNumberOfWarriors})";
        //    }
        //}

        private void Instance_WarBandChanged(object sender, EventArgs e)
        {
            UpdateAllProperties();
        }

        private void UpdateAllProperties()
        {
            //RaisePropertyChangedEvent(nameof(TotalCosts));
            //RaisePropertyChangedEvent(nameof(WarriorCountSummary));
            //RaisePropertyChangedEvent(nameof(WarbandRating));
            RaisePropertyChangedEvent(nameof(Name));
            RaisePropertyChangedEvent(nameof(MaximumWarriorOfNumbers));
            RaisePropertyChangedEvent(nameof(Description));
        }
    }
}