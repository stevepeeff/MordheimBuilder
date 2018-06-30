using DomainModel.Warbands;
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

namespace MordheimBuilder.Views
{
    /// <summary>
    /// Interaction logic for WarriorSimpleView.xaml
    /// </summary>
    public partial class WarriorSimpleView : UserControl
    {
        private WarriorViewModel _ViewModel = null;

        public WarriorSimpleView()
        {
            InitializeComponent();
        }

        public WarriorSimpleView(IWarrior warrior) : this()
        {
            _ViewModel = new WarriorViewModel(warrior);
            this.DataContext = _ViewModel;
            _StatisticsView.Warrior = _ViewModel.Warrior;
        }
    }
}