using DomainModel;
using DomainModel.Warbands;
using MordheimBuilderLogic;
using MordheimDal.Interface;
using MordheimDal.XmlStorage;
using MordheimXmlDal.XmlStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimDal
{
    internal class XmlDal : IDAL
    {
        public static string STORAGE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), STORAGE_FOLDER);
        private const string FILE_EXTENSION = ".xml";
        private const string FILENAME = "Warband Roster";
        private const string STORAGE_FOLDER = "Mordheim Builder";

        public string DefaultStorageDirectory => STORAGE_PATH;

        public void Load(string file)
        {
            LoadWarband(file);
        }

        public IWarbandRoster LoadWarband(string file)
        {
            if (!File.Exists(file)) { throw new FileNotFoundException($"Cannot find file {file}"); }

            XmlHeadNode xmlHeadNode = XMLUtils.Load<XmlHeadNode>(file);

            BuilderLogicFactory.Instance.SelectWarBand(xmlHeadNode.WarbandRoster.Warband);

            IWarbandRoster warbandRoster = BuilderLogicFactory.Instance.WarbandRoster;

            foreach (var xmlWarrior in xmlHeadNode.WarbandRoster.WarriorList)
            {
                IWarrior warrior = warbandRoster.FromXml(xmlWarrior);
            }

            return warbandRoster;
        }

        public void Save(IWarbandRoster roster)
        {
            if (roster == null) { throw new ArgumentNullException("The IWarbandRoster is null"); }

            string rosterName = roster.Name;
            string filename = BuildFileNameAndCreateStoragerDirectory(rosterName);

            XmlHeadNode xmlHeadNode = new XmlHeadNode();
            xmlHeadNode.WarbandRoster.Name = rosterName;
            xmlHeadNode.WarbandRoster.Warband = roster.WarBand.WarBandName;

            foreach (IWarrior warrior in roster.Warriors)
            {
                xmlHeadNode.WarbandRoster.WarriorList.Add(warrior.ToXml());
            }

            XMLUtils.AtomicSave<XmlHeadNode>(xmlHeadNode, Path.Combine(STORAGE_PATH, filename));
        }

        public void Save(IWarbandRoster roster, string specificFileName)
        {
            if (roster == null) { throw new ArgumentNullException("The IWarbandRoster is null"); }

            XmlHeadNode xmlHeadNode = roster.ToXml();

            foreach (IWarrior warrior in roster.Warriors)
            {
                xmlHeadNode.WarbandRoster.WarriorList.Add(warrior.ToXml());
            }

            SaveXml(specificFileName, xmlHeadNode);
        }

        private static string BuildFileNameAndCreateStoragerDirectory(string rosterName)
        {
            Directory.CreateDirectory(STORAGE_PATH);

            if (String.IsNullOrEmpty(rosterName))
            {
                return $"{FILENAME} {DateTime.Now.ToShortDateString()}{FILE_EXTENSION}";
            }
            else
            {
                return $"{FILENAME} {rosterName}{FILE_EXTENSION}";
            }
        }

        private static void SaveXml(string specificFileName, XmlHeadNode xmlHeadNode)
        {
            string storageName = specificFileName;
            if (specificFileName.EndsWith(FILE_EXTENSION, StringComparison.CurrentCultureIgnoreCase) == false)
            {
                storageName += FILE_EXTENSION;
            }

            XMLUtils.AtomicSave<XmlHeadNode>(xmlHeadNode, Path.Combine(STORAGE_PATH, storageName));
        }
    }
}