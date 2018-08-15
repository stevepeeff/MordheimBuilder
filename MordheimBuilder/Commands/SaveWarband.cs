using Microsoft.Win32;
using MordheimBuilderLogic;
using MordheimDal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class SaveWarband : CommandBase
    {
        public override void Execute(object parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.InitialDirectory = Path.Combine(DalProvider.Instance.DefaultStorageDirectory);
            saveFile.FileName = BuilderLogicFactory.Instance.WarbandRoster.Name;
            if (String.IsNullOrWhiteSpace(saveFile.FileName))
            {
                saveFile.FileName = BuilderLogicFactory.Instance.WarbandRoster.WarBand.WarBandName;
            }
            if (saveFile.ShowDialog() == true)
            {
                DalProvider.Instance.Save(BuilderLogicFactory.Instance.WarbandRoster, saveFile.FileName);
            }
        }
    }
}