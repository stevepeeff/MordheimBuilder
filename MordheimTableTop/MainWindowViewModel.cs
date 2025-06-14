﻿using DomainModel;
using DomainModel.Warbands;
using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.WitchHunters;
using Microsoft.Win32;
using MordheimBuilderLogic;
using MordheimDal;
using MordheimTableTop.Selection;
using MordheimTableTop.Warband;
using System;
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
            BuilderLogicFactory.Instance.WarbandRosterChanged += Instance_WarbandRosterChanged;

            //TODO remove
            Test();
        }

        public ICommand EditModeCommand => new RelayCommand(x => EditModus());

        private void EditModus()
        {
            MainWindowContent = new WarBandBuyViewModel();
            MainWindowRightContent = new WarBandEditViewModel();
        }

        public ICommand LoadCommand => new RelayCommand(x => Load());

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

        public ICommand PlayModeCommand { get; set; }

        public ICommand SaveAsCommand => new RelayCommand(x => SaveAs(), WarbandRosterIsSet());

        public ICommand SaveCommand => new RelayCommand(x => Save(), WarbandRosterIsSet());

        public IWarrior TestWarrior => new WitchHunterCaptain();

        private void Instance_WarbandRosterChanged(object sender, WarBandRosterEventArgs e)
        {
            MainWindowContent = new WarBandBuyViewModel();
            //  MainWindowRightContent = new WarBandBuyViewModel();
            MainWindowRightContent = new WarBandEditViewModel();
        }

        private void Load()
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                InitialDirectory = DalProvider.Instance.DefaultStorageDirectory,
                Filter = "XML files (*.xml)|*.xml"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                DalProvider.Instance.Load(openFileDialog.FileName);
            }
        }

        private void Save()
        {
            IWarbandRoster roster = BuilderLogicFactory.Instance.WarbandRoster;
            if (String.IsNullOrWhiteSpace(roster.SaveFileName))
            {
                ShowSaveSuccessMessage(DalProvider.Instance.Save(roster));
            }
            else
            {
                ShowSaveSuccessMessage(DalProvider.Instance.Save(roster, roster.SaveFileName));
            }
        }

        private void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = DalProvider.Instance.DefaultStorageDirectory
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                IWarbandRoster roster = BuilderLogicFactory.Instance.WarbandRoster;
                ShowSaveSuccessMessage(DalProvider.Instance.Save(roster, saveFileDialog.FileName));
                roster.SaveFileName = saveFileDialog.FileName;
            }
        }

        private void ShowSaveSuccessMessage(string storagePath)
        {
            MessageBox.Show($"Roster saved as: {Environment.NewLine}{storagePath}", "Save success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowWarbandSelection()
        {
            var warbandSelectionViewModel = new WarbandSelectionViewModel();
            MainWindowContent = warbandSelectionViewModel;
            warbandSelectionViewModel.WarbandSelected += WarbandSelectionViewModel_WarbandSelected;
        }

        private void Test()
        {
            //Invoke warband selected
            // var rndWarband = BuilderLogicFactory.Instance.AvailableWarbands.ElementAt(new Random().Next(0, 5));
            var rndWarband = new CultOfThePossessedWarband();
            BuilderLogicFactory.Instance.SelectWarBand(rndWarband);

            //Show EquipmentSelection
            //MainWindowContent = new EquipmentSelectionViewModel(TestWarrior);
        }

        private bool WarbandRosterIsSet()
        {
            if (BuilderLogicFactory.Instance.WarbandRoster != null)
            {
                return (!BuilderLogicFactory.Instance.WarbandRoster.CostsExceedMaximum);
            }
            return false;
        }

        private void WarbandSelectionViewModel_WarbandSelected(object sender, WarbandEventArgs e)
        {
            // TODO fix this=>  warbandSelectionViewModel.WarbandSelected -= WarbandSelectionViewModel_WarbandSelected;
            BuilderLogicFactory.Instance.SelectWarBand(e.SelectedWarband);

            MainWindowContent = new WarBandBuyViewModel();
            //  MainWindowRightContent = new WarBandBuyViewModel();
            MainWindowRightContent = new WarBandEditViewModel();
        }
    }
}