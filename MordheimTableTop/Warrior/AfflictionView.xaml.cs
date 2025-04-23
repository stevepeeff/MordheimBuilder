using System.Windows.Controls;

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