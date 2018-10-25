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
    internal class WarbandBuilderViewModel : ViewModelBase
    {
        public WarbandBuilderViewModel(IWarBand warBand)
        {
        }

        public ObservableCollection<WarriorViewModel> Warriors { get; } = new ObservableCollection<WarriorViewModel>();

        public IWarBand Warband { get; }
    }
}