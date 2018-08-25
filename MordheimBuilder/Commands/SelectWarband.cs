using MordheimBuilder.ViewModels;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class SelectWarband : CommandBase
    {
        private WarBandOverallViewModel mWarBandOverallViewModel;

        public SelectWarband(WarBandOverallViewModel warBandOverallViewModel)
        {
            mWarBandOverallViewModel = warBandOverallViewModel;
        }

        public override void Execute(object parameter)
        {
            // BuilderLogicFactory.Instance.SelectWarBand(mWarBandOverallViewModel.SelectedWarband.Warband);

            //TODO proper close, via Interface I'd prefere
            //DO
            //Who is goint to close the control??
            //Window window = Window.GetWindow(this);
            //window.Close();
            mWarBandOverallViewModel.ViewInterface.Close();
        }
    }
}