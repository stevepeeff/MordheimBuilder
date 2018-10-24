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

        /// <summary>
        /// Initializes a new instance of the <see cref="WarriorView"/> class.
        /// </summary>
        public WarriorView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WarriorView"/> class.
        /// </summary>
        /// <param name="warrior">The warrior.</param>
        public WarriorView(IWarrior warrior) : this()
        {
            _ViewModel = new WarriorViewModel(warrior);
            this.DataContext = _ViewModel;

            _ExpierenceView.BuildRoster(_ViewModel.Warrior);

            _AfflictionsView.ViewModel = new AfflictionsViewModel(_ViewModel.Warrior.Afflictions);
            _ViewModel.ExperienceList = _ExpierenceView.ExperienceList;
        }
    }
}