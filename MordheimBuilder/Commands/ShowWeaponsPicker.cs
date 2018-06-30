using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MordheimBuilder.Commands
{
    internal class ShowWeaponsPicker : WariorViewCommandBase
    {
        public ShowWeaponsPicker(WarriorViewModel warriorViewModel) : base(warriorViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            WeaponPickerView weaponView = new WeaponPickerView()
            {
                ViewModel = new EquipmentViewModel(WarriorView)
            };

            Window window = new Window()
            {
                Content = weaponView
            };

            window.ShowDialog();
        }
    }
}