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
        private WarBandOverallViewModel _WarBandOverallViewModel;

        public SelectWarband(WarBandOverallViewModel warBandOverallViewModel)
        {
            _WarBandOverallViewModel = warBandOverallViewModel;
        }

        public override void Execute(object parameter)
        {
            BuilderLogicFactory.Instance.SelectWarBand(_WarBandOverallViewModel.SelectedWarband.Warband);
            BuilderLogicFactory.Instance.PlayModus = Modus.Edit;

            _WarBandOverallViewModel.ViewInterface.Close();
        }
    }
}