using System.Windows;
using System.Windows.Controls;

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