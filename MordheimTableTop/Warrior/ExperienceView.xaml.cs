using DomainModel.Warbands;
using System.Windows;
using System.Windows.Controls;

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

        ~ExperienceView()
        {
            DataContextChanged -= ExperienceView_DataContextChanged;
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

        private void ExperienceView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is IWarrior)
            {
                IWarrior warrior = DataContext as IWarrior;
                if (warrior.MaximumExperience == 0)
                {
                    this.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BuildRoster(warrior);
                }
            }
        }
    }
}