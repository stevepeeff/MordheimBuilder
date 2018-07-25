using DomainModel.Warbands;
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
    /// Interaction logic for ExpierenceView.xaml
    /// </summary>
    public partial class ExpierenceView : UserControl
    {
        public IReadOnlyCollection<IExperience> ExperienceList { get { return _ExperienceList; } }

        private List<IExperience> _ExperienceList = new List<IExperience>();

        public ExpierenceView()
        {
            InitializeComponent();
        }

        public ExpierenceView(IWarrior warrior) : this()
        {
            BuildRoster(warrior);
        }

        public void BuildRoster(IWarrior warrior)
        {
            _ExperienceList.Clear();
            this.m_StackPanel.Children.Clear();

            int numberOFRows = warrior.MaximumExperience / 10;

            int overallCounter = 1;
            for (int rowCounter = 0; rowCounter < numberOFRows; rowCounter++)
            {
                StackPanel panel = new StackPanel() { Orientation = Orientation.Horizontal };

                for (int i = 0; i < warrior.MaximumExperience; i++)
                {
                    //mmmm TODO logic and knowledge of a domain model
                    bool hasThickborder = warrior.IsLevelUp(overallCounter);
                    bool isChecked = overallCounter < warrior.CurrentExperience;
                    IExperience exp = new Experience(overallCounter, hasThickborder, isChecked);
                    overallCounter++;
                    _ExperienceList.Add(exp);
                    panel.Children.Add(exp as Experience);
                }
                this.m_StackPanel.Children.Add(panel);
            }
        }
    }
}