using Microsoft.Win32;
using MordheimDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class LoadWarband : CommandBase
    {
        private MainWindow _mainWindow;

        public LoadWarband(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog loadFile = new OpenFileDialog();
            //TODO set filter and folder
            loadFile.InitialDirectory = DalProvider.Instance.DefaultStorageDirectory;

            //loadFile.Filter = "Xml Files (*.xml)";
            loadFile.Multiselect = false;
            if (loadFile.ShowDialog() == true)
            {
                DalProvider.Instance.Load(loadFile.FileName);
            }

            _mainWindow.EditModeCommand.Execute(null);
        }
    }
}