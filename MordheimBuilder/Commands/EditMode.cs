using MordheimBuilder.Views.ModusView;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class EditMode : MainWindowCommandBase
    {
        public EditMode(MainWindow mainWindow) : base(mainWindow)
        {
        }

        public override void Execute(object parameter)
        {
            BuilderLogicFactory.Instance.PlayModus = Modus.Edit;
            _MainWindow._StackPanelMainWindowContent.Children.Clear();
            _MainWindow._StackPanelMainWindowContent.Children.Add(new ModusEditView());
        }
    }
}