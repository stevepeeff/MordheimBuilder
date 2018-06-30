using DomainModel.Psychology;
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
    /// Interaction logic for AfflictionsView.xaml
    /// </summary>
    public partial class AfflictionsView : UserControl
    {
        private AfflictionsViewModel _AfflictionsViewModel;

        public AfflictionsViewModel ViewModel
        {
            get { return _AfflictionsViewModel; }
            set
            {
                _AfflictionsViewModel = value;
                this.DataContext = ViewModel;
            }
        }

        public AfflictionsView()
        {
            InitializeComponent();
        }

        public AfflictionsView(IReadOnlyCollection<IPsychology> afflictions) : this()
        {
            ViewModel = new AfflictionsViewModel(afflictions);
        }
    }
}