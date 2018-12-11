using DomainModel.Warbands;
using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.WitchHunters;
using Microsoft.Win32;
using MordheimBuilderLogic;
using MordheimDal;
using MordheimTableTop.Selection;
using MordheimTableTop.Warband;
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
        private ViewModelBase _MainWindowRightContent;

        public MainWindowViewModel()
        {
            //TODO remove
            Test();
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

        public ViewModelBase MainWindowRightContent
        {
            get { return _MainWindowRightContent; }
            private set
            {
                if (_MainWindowRightContent != value)
                {
                    _MainWindowRightContent = value;
                    NotifiyPropertyChangedEvent();
                }
            }
        }

        public ICommand NewWarbandCommand => new RelayCommand(x => ShowWarbandSelection());

        public ICommand LoadCommand => new RelayCommand(x => Load());

        private void Load()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = DalProvider.Instance.DefaultStorageDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                //txtEditor.Text = File.ReadAllText(openFileDialog.FileName);

                //DalProvider.Instance.Load
            }
        }

        public ICommand SaveCommand => new RelayCommand(x => Save());

        private void Save()
        {
            throw new NotImplementedException();
        }

        public ICommand SaveAsCommand => new RelayCommand(x => SaveAs());

        private void SaveAs()
        {
            throw new NotImplementedException();
        }

        public ICommand PlayModeCommand { get; set; }

        private void ShowWarbandSelection()
        {
            var warbandSelectionViewModel = new WarbandSelectionViewModel();
            MainWindowContent = warbandSelectionViewModel;
            warbandSelectionViewModel.WarbandSelected += WarbandSelectionViewModel_WarbandSelected;
        }

        public IWarrior TestWarrior => new WitchHunterCaptain();

        private void Test()
        {
            //Invoke warband selected
            // var rndWarband = BuilderLogicFactory.Instance.AvailableWarbands.ElementAt(new Random().Next(0, 5));
            var rndWarband = new CultOfThePossessedWarband();
            WarbandSelectionViewModel_WarbandSelected(this, new WarbandEventArgs(rndWarband));

            //Show EquipmentSelection
            //MainWindowContent = new EquipmentSelectionViewModel(TestWarrior);
        }

        private void WarbandSelectionViewModel_WarbandSelected(object sender, WarbandEventArgs e)
        {
            BuilderLogicFactory.Instance.SelectWarBand(e.SelectedWarband);

            MainWindowContent = new WarBandBuyViewModel();
            //  MainWindowRightContent = new WarBandBuyViewModel();
            MainWindowRightContent = new WarBandEditViewModel();
        }
    }
}