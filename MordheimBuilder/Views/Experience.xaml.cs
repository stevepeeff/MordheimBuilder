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
    /// Interaction logic for Experience.xaml
    /// </summary>
    public partial class Experience : UserControl, IExperience
    {
        public Experience()
        {
            InitializeComponent();
        }

        public Experience(int index, bool hasThickBorder, bool isChecked) : this()
        {
            DataContext = this;
            Index = index;
            IsChecked = isChecked;

            if (hasThickBorder)
            {
                _CheckBox.BorderThickness = new Thickness(2.5);
            }
            else
            {
                _CheckBox.BorderThickness = new Thickness(1.0);
            }
        }

        public int Index { get; private set; }

        public bool IsChecked
        {
            get { return (bool)_CheckBox.IsChecked; }
            set { _CheckBox.IsChecked = value; }
        }
    }
}