using DomainModel.Warbands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop.Selection
{
    internal class WarbandSelectionViewModel : ViewModelBase
    {
        private IWarBand _Warband;

        public WarbandSelectionViewModel()
        {
            foreach (var item in BuilderLogicFactory.Instance.AvailableWarbands)
            {
                Warbands.Add(new WarbandSelectionViewModel(item));
            }
        }

        private WarbandSelectionViewModel(IWarBand warband)
        {
            _Warband = warband;
        }

        public ICommand CloseWindowCommand { get; }

        public event EventHandler<WarbandEventArgs> WarbandSelected;

        public int MaximumAmountOfWarriors => _Warband.MaximumNumberOfWarriors;
        public WarbandSelectionViewModel SelectedWarband { get; set; }
        public int StartingCash => _Warband.StartingCash;
        public string WarbandName => _Warband.WarBandName.SplitCamelCasing();

        public IList<WarbandSelectionViewModel> Warbands { get; } = new List<WarbandSelectionViewModel>();
        public ICommand WarbandSelectedCommand => new RelayCommand(x => InvokeWarbandSelected());

        private void InvokeWarbandSelected()
        {
            if (WarbandSelected != null && SelectedWarband != null)
            {
                WarbandSelected.Invoke(this, new WarbandEventArgs(SelectedWarband._Warband));
            }
        }
    }
}