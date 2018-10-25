using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using MordheimTableTop.Selection;
using MordheimTableTop.Warrior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MordheimTableTop
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _MainWindowContent;

        public MainWindowViewModel()
        {
            Test();
            //NewWarbandCommand.Execute(null);
        }

        public ICommand EditModeCommand { get; set; }

        public ViewModelBase MainWindowContent
        {
            get { return _MainWindowContent; }
            private set
            {
                if (_MainWindowContent != value)
                {
                    _MainWindowContent = value;
                    NotifiyPropertyChangedEvent();
                }
            }
        }

        public ICommand NewWarbandCommand => new RelayCommand(x => ShowWarbandSelection());
        public ICommand PlayModeCommand { get; set; }

        private void ShowWarbandSelection()
        {
            var warbandSelectionViewModel = new WarbandSelectionViewModel();
            MainWindowContent = warbandSelectionViewModel;
            warbandSelectionViewModel.WarbandSelected += WarbandSelectionViewModel_WarbandSelected;
        }

        private void Test()
        {
            IWarrior warrior = new WitchHunterCaptain();
            MainWindowContent = new WarriorBuyViewModel(warrior);
        }

        private void WarbandSelectionViewModel_WarbandSelected(object sender, WarbandEventArgs e)
        {
            MainWindowContent = null;
        }
    }
}