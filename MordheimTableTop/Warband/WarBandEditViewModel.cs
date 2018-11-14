using DomainModel;
using MordheimBuilderLogic;
using MordheimTableTop.Warrior;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Warband
{
    internal class WarBandEditViewModel : ViewModelBase
    {
        public WarBandEditViewModel()
        {
            BuilderLogicFactory.Instance.WarbandRoster.WarBandChanged += WarbandRoster_WarBandChanged;
        }

        /// <summary>
        /// Gets the roster.
        /// </summary>
        /// <value>
        /// The roster.
        /// </value>
        public IWarbandRoster Roster { get; } = BuilderLogicFactory.Instance.WarbandRoster;

        public int TotalNumberOfWarriors { get { return Roster.TotalNumberOfWarriors; } }
        public int TotalCosts { get { return Roster.TotalCosts; } }
        public int WarbandRating { get { return Roster.WarbandRating; } }

        /// <summary>
        /// Gets the warriors.
        /// </summary>
        /// <value>
        /// The warriors.
        /// </value>
        public ObservableCollection<WarriorViewModel> Warriors { get; } = new ObservableCollection<WarriorViewModel>();

        private void WarbandRoster_WarBandChanged(object sender, EventArgs e)
        {
            foreach (var item in Warriors)
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
            NotifiyPropertyChangedEvent(nameof(WarbandRating));
        }

        private void WarriorViewModel_EquipmentListChanged(object sender, EventArgs e)
        {
            NotifiyPropertyChangedEvent(nameof(TotalCosts));
        }
    }
}