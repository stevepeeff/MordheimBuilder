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

namespace MordheimTableTop.Warrior
{
    /// <summary>
    /// Interaction logic for AfflictionView.xaml
    /// </summary>
    public partial class AfflictionView : UserControl
    {
        public AfflictionView() : this(null)
        {
        }

        public AfflictionView(AfflictionViewModel afflictionViewModel)
        {
            InitializeComponent();
            if (afflictionViewModel != null)
            {
                this.DataContext = afflictionViewModel;
            }
        }
    }
}