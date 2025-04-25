using DomainModel;
using DomainModel.Warbands;
using MordheimBuilderLogic;
using MordheimDal.Interface;
using MordheimDal.XmlStorage;
using MordheimXmlDal.XmlStorage;
using System;
using System.IO;

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

        public string Save(IWarbandRoster roster)
        {
            if (roster == null) { throw new ArgumentNullException("The IWarbandRoster is null"); }

            string rosterName = roster.Name;
            string filename = BuildFileNameAndCreateStoragerDirectory(rosterName);

            return Save(roster, Path.Combine(STORAGE_PATH, filename));
        }

        /// <summary>
        /// Saves the specified roster.
        /// </summary>
        /// <param name="roster">The roster.</param>
        /// <param name="specificFileName">Name of the specific file.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">The IWarbandRoster is null</exception>
        public string Save(IWarbandRoster roster, string specificFileName)
        {
            if (roster == null) { throw new ArgumentNullException("The IWarbandRoster is null"); }

            XmlHeadNode xmlHeadNode = roster.ToXml();

            foreach (IWarrior warrior in roster.Warriors)
            {
                xmlHeadNode.WarbandRoster.WarriorList.Add(warrior.ToXml());
            }

            SaveXml(specificFileName, xmlHeadNode);

            return specificFileName;
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