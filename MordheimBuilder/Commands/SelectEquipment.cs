using DomainModel.Equipment;
using MordheimBuilder.ViewModels;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class SelectEquipment : CommandBase
    {
        private EquipmentViewModel _EquipmentViewModel;

        public SelectEquipment(EquipmentViewModel equipmentViewModel)
        {
            if (equipmentViewModel == null) { throw new ArgumentNullException("EquipmentViewModel is null"); }

            _EquipmentViewModel = equipmentViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is CloseCombatWeaponViewModel)
            {
                var closeCombatWeaponViewModel = parameter as CloseCombatWeaponViewModel;

                _EquipmentViewModel.WarriorViewModel.AddEquipment(new EquipmentSummaryViewModel(closeCombatWeaponViewModel.CloseCombatWeapon));
            }
            else if (parameter is MissileWeaponViewModel)
            {
                var missileWeaponViewModel = parameter as MissileWeaponViewModel;
                _EquipmentViewModel.WarriorViewModel.AddEquipment(new EquipmentSummaryViewModel(missileWeaponViewModel.MisseleWeapon));
            }
            else if (parameter is ArmorViewModel)
            {
                var armorViewModel = parameter as ArmorViewModel;
                _EquipmentViewModel.WarriorViewModel.AddEquipment(new EquipmentSummaryViewModel(armorViewModel.Armour));
            }
        }

        public override bool CanExecute(object parameter)
        {
            return BuilderLogicFactory.Instance.PlayModus == Modus.Edit;
        }
    }
}