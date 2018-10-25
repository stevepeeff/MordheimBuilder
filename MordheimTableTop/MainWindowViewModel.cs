using MordheimTableTop.Selection;
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
        public ICommand EditModeCommand { get; set; }

        public ICommand PlayModeCommand { get; set; }

        public ICommand NewWarbandCommand => new RelayCommand(x => ShowWarbandSelection());

        private ViewModelBase _MainWindowContent;

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

        private void ShowWarbandSelection()
        {
            var warbandSelectionViewModel = new WarbandSelectionViewModel();
            MainWindowContent = warbandSelectionViewModel;
            warbandSelectionViewModel.WarbandSelected += WarbandSelectionViewModel_WarbandSelected;
        }

        private void WarbandSelectionViewModel_WarbandSelected(object sender, WarbandEventArgs e)
        {
            MainWindowContent = null;
        }

        public MainWindowViewModel()
        {
            NewWarbandCommand.Execute(null);
        }
    }
}