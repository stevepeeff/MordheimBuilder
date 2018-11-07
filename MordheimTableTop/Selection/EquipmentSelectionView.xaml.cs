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

namespace MordheimTableTop.Selection
{
    /// <summary>
    /// Interaction logic for EquipmentSelectionView.xaml
    /// </summary>
    public partial class EquipmentSelectionView : UserControl
    {
        public EquipmentSelectionView()
        {
            InitializeComponent();
        }

        public EquipmentSelectionView(EquipmentSelectionViewModel equipmentSelectionViewModel) : this()
        {
            this.DataContext = equipmentSelectionViewModel;
        }
    }
}