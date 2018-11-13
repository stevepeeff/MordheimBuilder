using DomainModel.Warbands;
using MordheimTableTop.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MordheimTableTop.Warrior.Commands
{
    internal class ShowEquipmentSelection : CommandBase
    {
        private EquipmentSelectionViewModel _EquipmentSelectionViewModel;

        public ShowEquipmentSelection(EquipmentSelectionViewModel equipmentSelectionViewModel)
        {
            _EquipmentSelectionViewModel = equipmentSelectionViewModel;
        }

        public override void Execute(object parameter)
        {
            Window _Window = new Window()
            {
                Content = new EquipmentSelectionView(_EquipmentSelectionViewModel)
            };
            _Window.Show();
        }
    }
}