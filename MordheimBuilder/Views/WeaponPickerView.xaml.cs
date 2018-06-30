using DomainModel.Equipment;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MordheimBuilder
{
    /// <summary>
    /// Interaction logic for WeaponPickerView.xaml
    /// </summary>
    public partial class WeaponPickerView : UserControl
    {
        private EquipmentViewModel _WeaponViewModel;

        public EquipmentViewModel ViewModel
        {
            get { return _WeaponViewModel; }
            set
            {
                _WeaponViewModel = value;

                this.DataContext = ViewModel;
            }
        }

        public WeaponPickerView()
        {
            InitializeComponent();
        }
    }
}