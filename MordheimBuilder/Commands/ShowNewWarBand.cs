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
        public ShowNewWarBand()
        {
        }

        public override void Execute(object parameter)
        {
            WarbandPickerView pickrViw = new WarbandPickerView();

            Window window = new Window()
            {
                Content = pickrViw
            };

            if (window.ShowDialog() == true)
            {
                window.Close();
            }
        }
    }
}