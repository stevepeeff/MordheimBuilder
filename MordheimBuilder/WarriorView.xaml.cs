using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using MordheimBuilder.ViewModels;
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
    /// Interaction logic for WarriorView.xaml
    /// </summary>
    public partial class WarriorView : UserControl
    {
        private WarriorViewModel _ViewModel = null;

        public WarriorViewModel ViewModel
        {
            get { return _ViewModel; }
            set
            {
                _ViewModel = value;
                this.DataContext = ViewModel;
                _StatisticsView.Warrior = ViewModel.Warrior;
                _ExpierenceView.BuildRoster(ViewModel.Warrior);
                _EquipWeaponsView.ViewModel = new WeaponViewModel(ViewModel.Warrior);
                _AfflictionsView.ViewModel = new AfflictionsViewModel(ViewModel.Warrior.Afflictions);
                ViewModel.ExperienceList = _ExpierenceView.ExperienceList;
            }
        }

        public WarriorView()
        {
            InitializeComponent();
        }

        public WarriorView(IWarrior warrior) : this()
        {
            ViewModel = new WarriorViewModel(warrior);
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the GroupBox control.
        /// TODO MAKE ICommand
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void GroupBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window window = new Window()
            {
                Content = new WeaponPickerView() { ViewModel = new WeaponViewModel(ViewModel.Warrior) }
            };

            window.ShowDialog();
            // window.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}