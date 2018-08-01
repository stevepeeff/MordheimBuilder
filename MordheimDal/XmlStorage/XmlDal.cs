using DomainModel;
using DomainModel.Warbands;

using MordheimDal.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimDal.XmlStorage
{
    internal class XmlDal : IDAL
    {
        private const string STORAGE_FOLDER = "Mordheim Builder";
        private const string FILENAME = "Warband Roster";
        private const string FILE_EXTENSION = ".XML";
        public static string STORAGE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), STORAGE_FOLDER);

        public XmlDal()
        {
            // Environment.SpecialFolder.MyDocuments;
        }

        public IWarBand Load(string file)
        {
            if (!File.Exists(file)) { throw new FileNotFoundException($"Cannot find file {file}"); }

            XmlHeadNode xmlHeadNode = XMLUtils.Load<XmlHeadNode>(file);

            IWarBand warband = WarBandProvider.Instance.GetWarband(xmlHeadNode.WarbandRoster.Warband);

            //IWarbandRoster loadResult = new WarBandRoster

            //loadResult.WarBandName = xmlHeadNode.WarbandRoster.Name;
            //return loadResult;
            return warband;
        }

        public void Save(IWarbandRoster roster)
        {
            string rosterName = roster.Name;
            string filename = BuildFileNameAndCreateStoragerDirectory(rosterName);

            XmlHeadNode xmlHeadNode = new XmlHeadNode();
            xmlHeadNode.WarbandRoster.Name = rosterName;
            xmlHeadNode.WarbandRoster.Warband = roster.WarBand.WarBandName;

            XMLUtils.AtomicSave<XmlHeadNode>(xmlHeadNode, Path.Combine(STORAGE_PATH, filename));
        }

        private static string BuildFileNameAndCreateStoragerDirectory(string rosterName)
        {
            string filename;
            if (String.IsNullOrEmpty(rosterName))
            {
                filename = $"{FILENAME} {DateTime.Now.ToShortDateString()}{FILE_EXTENSION}";
            }
            else
            {
                filename = $"{FILENAME} {rosterName}{FILE_EXTENSION}";
            }

            Directory.CreateDirectory(STORAGE_PATH);
            return filename;
        }
    }
}