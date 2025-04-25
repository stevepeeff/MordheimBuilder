using System.Windows.Controls;

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