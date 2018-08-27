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

        public override bool CanExecute(object parameter)
        {
            return (BuilderLogicFactory.Instance.WarbandRoster != null);
        }

        public override void Execute(object parameter)
        {
            BuilderLogicFactory.Instance.PlayModus = Modus.Play;
        }
    }
}