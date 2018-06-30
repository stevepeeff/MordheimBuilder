using DomainModel.Warbands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    internal class WarBandRosterViewModel : ViewModelBase
    {
        public WarBandRosterViewModel()
        {
            BuilderLogicFactory.Instance.WarbandRoster.WarBandChanged += WarbandRoster_WarBandChanged;
        }

        public ObservableCollection<IWarrior> Warriors { get; } = new ObservableCollection<IWarrior>(BuilderLogicFactory.Instance.WarbandRoster.Warriors);

        private void WarbandRoster_WarBandChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}