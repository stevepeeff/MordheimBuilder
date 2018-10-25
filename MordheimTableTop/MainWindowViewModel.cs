using MordheimTableTop.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ICommand EditModeCommand { get; set; }

        public ICommand PlayModeCommand { get; set; }

        public ICommand NewWabandCommand => new RelayCommand(x => ShowWarbandSelection());

        private void ShowWarbandSelection()
        {
            WarbandSelectionViewModel warbandSelectionViewModel = new WarbandSelectionViewModel();
        }

        public MainWindowViewModel()
        {
        }
    }
}