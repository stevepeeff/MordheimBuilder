using DomainModel;
using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
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
    internal class WarbandBuilderViewModel : ViewModelBase
    {
        public WarbandBuilderViewModel()
        {
            BuilderLogicFactory.Instance.WarbandRoster.WarBandChanged += WarbandRoster_WarBandChanged;
            //TODO remove
            var warrior = new WitchHunterCaptain();
            Warriors.Add(new WarriorViewModel(warrior));
        }

        public IWarbandRoster Roster { get; } = BuilderLogicFactory.Instance.WarbandRoster;

        /// <summary>
        /// Gets the warband statistics.
        /// </summary>
        /// <value>
        /// The warband statistics.
        /// </value>
        public string WarbandStatistics
        {
            get
            {
                return $"Number of Warriors: {Roster.TotalNumberOfWarriors} \t" +
                    $"Costs: {Roster.TotalCosts} \t" +
                    $"Rating {Roster.WarbandRating}";
            }
        }

        public ObservableCollection<WarriorViewModel> Warriors { get; } = new ObservableCollection<WarriorViewModel>();

        private void WarbandRoster_WarBandChanged(object sender, EventArgs e)
        {
            Warriors.Clear();
            foreach (var item in Roster.Warriors)
            {
                Warriors.Add(new WarriorViewModel(item));
            }
            NotifiyPropertyChangedEvent(nameof(WarbandStatistics));
        }
    }
}