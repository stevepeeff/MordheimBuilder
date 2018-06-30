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
    public partial class WarriorPlayView : UserControl
    {
        private WarriorViewModel _ViewModel = null;

        public WarriorPlayView()
        {
            InitializeComponent();
        }

        public WarriorPlayView(IWarrior warrior) : this()
        {
            _ViewModel = new WarriorViewModel(warrior);
            this.DataContext = _ViewModel;
            _StatisticsView.Warrior = _ViewModel.Warrior;
            _ExpierenceView.BuildRoster(_ViewModel.Warrior);

            _AfflictionsView.ViewModel = new AfflictionsViewModel(_ViewModel.Warrior.Afflictions);
            _ViewModel.ExperienceList = _ExpierenceView.ExperienceList;
        }
    }
}