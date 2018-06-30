using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal abstract class MainWindowCommandBase : CommandBase
    {
        protected MainWindow _MainWindow;

        protected MainWindowCommandBase(MainWindow mainWindow)
        {
            _MainWindow = mainWindow;
        }
    }
}