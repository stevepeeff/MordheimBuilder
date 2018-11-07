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
        private Window _Window = new Window();

        public ShowEquipmentSelection(EquipmentSelectionViewModel equipmentSelectionViewModel)
        {
            _Window.Content = new EquipmentSelectionView(equipmentSelectionViewModel);
        }

        public override void Execute(object parameter)
        {
            _Window.Show();
        }
    }
}