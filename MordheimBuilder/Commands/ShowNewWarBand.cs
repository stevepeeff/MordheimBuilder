using MordheimBuilder.ViewModels;
using MordheimBuilder.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MordheimBuilder.Commands
{
    internal class ShowNewWarBand : CommandBase
    {
        private WarBandOverallViewModel _WarBandViewModel;

        public ShowNewWarBand(WarBandOverallViewModel viewModel)
        {
            _WarBandViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            WarbandPickerView weaponView = new WarbandPickerView();

            Window window = new Window()
            {
                Content = weaponView
            };

            window.ShowDialog();
        }
    }
}