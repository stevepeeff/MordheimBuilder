using DomainModel.Warbands;
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
    internal class WarBandBuyViewModel : ViewModelBase
    {
        public ObservableCollection<WarriorBuyViewModel> Warriors { get; } = new ObservableCollection<WarriorBuyViewModel>();

        public WarBandBuyViewModel()
        {
            foreach (var item in Warband.Heroes)
            {
                Warriors.Add(new WarriorBuyViewModel(item));
            }
            foreach (var item in Warband.HenchMen)
            {
                Warriors.Add(new WarriorBuyViewModel(item));
            }
        }

        public IWarBand Warband { get; } = BuilderLogicFactory.Instance.WarbandRoster.WarBand;

        public string WarbandName => Warband.WarBandName.SplitCamelCasing();
    }
}