using MordheimBuilder.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MordheimBuilder.Commands
{
    internal class ShowSkillSelector : WariorViewCommandBase
    {
        public ShowSkillSelector(WarriorViewModel warriorViewModel) : base(warriorViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            SkillView skillView = new SkillView(WarriorView);

            Window window = new Window()
            {
                Content = skillView
            };

            window.ShowDialog();
        }
    }
}