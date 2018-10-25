using DomainModel.Warbands;
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

        public WarBandBuyViewModel(IWarBand warBand)
        {
            foreach (var item in warBand.Heroes)
            {
                Warriors.Add(new WarriorBuyViewModel(item));
            }
            foreach (var item in warBand.HenchMen)
            {
                Warriors.Add(new WarriorBuyViewModel(item));
            }
        }
    }
}