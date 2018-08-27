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
        private static WarbandPickerView _pickrView = new WarbandPickerView();
        private Window _window = new Window() { Content = _pickrView };

        public ShowNewWarBand()
        {
        }

        public override void Execute(object parameter)
        {
            _pickrView.CloseCalled += PickrView_CloseCalled;
            _window.ShowDialog();
        }

        private void PickrView_CloseCalled(object sender, EventArgs e)
        {
            _pickrView.CloseCalled -= PickrView_CloseCalled;
            _window.Close();
        }
    }
}