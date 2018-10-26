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
    /// Interaction logic for ExperienceCheckBox.xaml
    /// </summary>
    public partial class ExperienceCheckBox : CheckBox
    {
        public ExperienceCheckBox()
        {
            InitializeComponent();
            //BorderThickness = new Thickness(2.5);
        }

        public int Index { get; }

        public ExperienceCheckBox(int index, bool thickBorder) : this()
        {
            Index = index;

            if (thickBorder)
            {
                //BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }
    }
}