using MordheimBuilder.ViewModels;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class RemoveEquipment : CommandBase
    {
        private EquipmentViewModel _EquipmentViewModel;

        public RemoveEquipment(EquipmentViewModel equipmentViewModel)
        {
            if (equipmentViewModel == null) { throw new ArgumentNullException("EquipmentViewModel is null"); }

            _EquipmentViewModel = equipmentViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is EquipmentSummaryViewModel)
            {
                var equipmentSummaryViewModel = parameter as EquipmentSummaryViewModel;

                _EquipmentViewModel.WarriorViewModel.RemoveEquipment(equipmentSummaryViewModel);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return BuilderLogicFactory.Instance.PlayModus == Modus.Edit;
        }
    }
}