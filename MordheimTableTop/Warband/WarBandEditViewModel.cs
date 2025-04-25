using DomainModel;
using MordheimBuilderLogic;
using MordheimTableTop.Warrior;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MordheimTableTop.Warband
{
    internal class WarBandEditViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WarBandEditViewModel"/> class.
        /// </summary>
        public WarBandEditViewModel()
        {
            BuilderLogicFactory.Instance.WarbandRoster.WarBandChanged += WarbandRoster_WarBandChanged;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WarBandEditViewModel"/> class.
        /// </summary>
        ~WarBandEditViewModel()
        {
            BuilderLogicFactory.Instance.WarbandRoster.WarBandChanged -= WarbandRoster_WarBandChanged;
        }

        /// <summary>
        /// Gets the roster.
        /// </summary>
        /// <value>
        /// The roster.
        /// </value>
        public IWarbandRoster Roster { get; } = BuilderLogicFactory.Instance.WarbandRoster;

        public int TotalNumberOfWarriors
        { get { return Roster.TotalNumberOfWarriors; } }

        public int TotalCosts
        { get { return Roster.TotalCosts; } }

        public int WarbandRating
        { get { return Roster.WarbandRating; } }

        public SolidColorBrush CostsColour
        {
            get
            {
                if (Roster.CostsExceedMaximum) { return Brushes.Red; }
                return Brushes.Black;
            }
        }

        /// <summary>
        /// Gets the warriors.
        /// </summary>
        /// <value>
        /// The warriors.
        /// </value>
        public ObservableCollection<WarriorViewModel> Warriors { get; } = new ObservableCollection<WarriorViewModel>();

        private void WarbandRoster_WarBandChanged(object sender, EventArgs e)
        {
            foreach (WarriorViewModel item in Warriors)
            {
                item.EquipmentListChanged -= WarriorViewModel_EquipmentListChanged;
            }

            Warriors.Clear();

            foreach (var item in Roster.Warriors)
            {
                var warriorViewModel = new WarriorViewModel(item);
                warriorViewModel.EquipmentListChanged += WarriorViewModel_EquipmentListChanged;
                Warriors.Add(warriorViewModel);
            }

            NotifiyPropertyChangedEvent(nameof(TotalNumberOfWarriors));
            NotifiyPropertyChangedEvent(nameof(TotalCosts));
            NotifiyPropertyChangedEvent(nameof(CostsColour));
            NotifiyPropertyChangedEvent(nameof(WarbandRating));
        }

        private void WarriorViewModel_EquipmentListChanged(object sender, EventArgs e)
        {
            NotifiyPropertyChangedEvent(nameof(TotalCosts));
            NotifiyPropertyChangedEvent(nameof(CostsColour));
        }
    }
}