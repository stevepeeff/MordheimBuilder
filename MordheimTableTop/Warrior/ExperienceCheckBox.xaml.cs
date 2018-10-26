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
    public partial class ExperienceCheckBox : UserControl
    {
        public ExperienceCheckBox()
        {
            InitializeComponent();

            _ChechkBox.IsChecked = false;
        }

        public ExperienceCheckBox(int index, bool thickBorder, bool isChecked) : this()
        {
            Index = index;
            IsChecked = isChecked;
            if (thickBorder)
            {
                _ChechkBox.BorderThickness = new Thickness(2.5);
            }
        }

        public int Index { get; }

        public bool IsChecked
        {
            get
            {
                return _ChechkBox.IsChecked.Value;
            }
            set
            {
                _ChechkBox.IsChecked = value;
            }
        }
    }
}