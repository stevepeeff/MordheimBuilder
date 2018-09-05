using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class WarbandStatisticsViewModel : ViewModelBase
    {
        public WarbandStatisticsViewModel()
        {
            BuilderLogicFactory.Instance.WarbandRoster.WarBandChanged += WarbandRoster_WarBandChanged;
        }

        public int TotalCosts => BuilderLogicFactory.Instance.WarbandRoster.TotalCosts;

        public int WarbandRating => BuilderLogicFactory.Instance.WarbandRoster.WarbandRating;

        public int WarriorCountSummary => BuilderLogicFactory.Instance.WarbandRoster.TotalNumberOfWarriors;

        private void WarbandRoster_WarBandChanged(object sender, EventArgs e)
        {
            RaisePropertyChangedEvent(nameof(WarbandRating));
            RaisePropertyChangedEvent(nameof(WarriorCountSummary));
            RaisePropertyChangedEvent(nameof(TotalCosts));
        }
    }
}