using MordheimBuilder.Views;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class PlayMode : MainWindowCommandBase
    {
        public PlayMode(MainWindow mainWindow) : base(mainWindow)
        {
        }

        public override void Execute(object parameter)
        {
            BuilderLogicFactory.Instance.PlayModus = Modus.Play;
            _MainWindow._StackPanelMainWindowContent.Children.Clear();
            _MainWindow._StackPanelMainWindowContent.Children.Add(new WarbandRosterView());
        }
    }
}