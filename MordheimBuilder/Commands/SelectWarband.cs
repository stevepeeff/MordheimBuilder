using MordheimBuilder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class SelectWarband : CommandBase
    {
        public SelectWarband(WarBandOverallViewModel warBandOverallViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            //Who is goint to close the control??
            //Window window = Window.GetWindow(this);
            //window.Close();
        }
    }
}