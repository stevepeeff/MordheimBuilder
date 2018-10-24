using DomainModel.Warbands;
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

namespace MordheimBuilder.Views
{
    /// <summary>
    /// Interaction logic for WarriorSimpleView.xaml
    /// </summary>
    public partial class WarriorSimpleView : UserControl
    {
        public WarriorViewModel WarriorVM { get; }

        public WarriorSimpleView()
        {
            InitializeComponent();
        }

        public WarriorSimpleView(IWarrior warrior) : this()
        {
            WarriorVM = new WarriorViewModel(warrior);
        }
    }
}