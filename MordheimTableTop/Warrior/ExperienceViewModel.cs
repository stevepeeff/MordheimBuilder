using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MordheimTableTop.Warrior
{
    internal class ExperienceViewModel : ViewModelBase
    {
        public StackPanel ExperienceViewContent { get; }

        public ExperienceViewModel(IWarrior warrior)
        {
            ExperienceViewContent = new StackPanel();

            int numberOFRows = warrior.MaximumExperience / 10;

            int overallCounter = 1;
            for (int rowCounter = 0; rowCounter < numberOFRows; rowCounter++)
            {
                DockPanel dockPanel = new DockPanel();

                for (int i = 0; i < warrior.MaximumExperience; i++)
                {
                    bool hasThickborder = warrior.IsLevelUp(overallCounter);
                    bool isChecked = overallCounter < warrior.CurrentExperience;
                    var experienceCheckBox = new ExperienceCheckBox(overallCounter, hasThickborder)
                    {
                        IsChecked = isChecked
                    };
                    overallCounter++;
                    dockPanel.Children.Add(experienceCheckBox);
                }
                ExperienceViewContent.Children.Add(dockPanel);
            }

            //   NotifiyPropertyChangedEvent(nameof(ExperienceViewContent));
        }
    }
}