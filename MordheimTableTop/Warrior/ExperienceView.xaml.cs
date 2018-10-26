using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
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
    /// Interaction logic for ExperienceView.xaml
    /// </summary>
    public partial class ExperienceView : UserControl
    {
        public ExperienceView()
        {
            InitializeComponent();
            DataContextChanged += ExperienceView_DataContextChanged;
        }

        private void ExperienceView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is IWarrior)
            {
                BuildRoster(DataContext as IWarrior);
            }
        }

        private void BuildRoster(IWarrior warrior)
        {
            _StackPanel.Children.Clear();

            int numberOFRows = warrior.MaximumExperience / 10;
            int overallCounter = 1;

            _StackPanel.Width = 280;
            if (numberOFRows > 1) { _StackPanel.Width = 600; }
            for (int rowCounter = 0; rowCounter < numberOFRows; rowCounter++)
            {
                DockPanel dockPanel = new DockPanel();
                for (int i = 0; i < warrior.MaximumExperience; i++)
                {
                    bool hasThickborder = warrior.IsLevelUp(overallCounter);
                    bool isChecked = overallCounter < warrior.CurrentExperience;
                    var experienceCheckBox = new ExperienceCheckBox(overallCounter, hasThickborder, isChecked);
                    overallCounter++;
                    dockPanel.Children.Add(experienceCheckBox);
                }
                _StackPanel.Children.Add(dockPanel);
            }
        }
    }
}