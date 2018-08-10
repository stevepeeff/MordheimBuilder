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
        private const string STORAGE_FOLDER = "Mordheim Builder";
        private const string FILENAME = "Warband Roster";
        private const string FILE_EXTENSION = ".XML";
        public static string STORAGE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), STORAGE_FOLDER);

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
                IWarrior warrior = warbandRoster.WarBand.GetWarrior(xmlWarrior.TypeOfWarrior);

                warrior = warbandRoster.AddWarrior(warrior);
                foreach (string item in xmlWarrior.EquipmentList)
                {
                    warrior.AddEquipment(item);
                }
                if (warrior is IHenchMan)
                {
                    IHenchMan henchMan = warrior as IHenchMan;

                    for (int i = 1; i < xmlWarrior.AmountInGroup; i++)
                    {
                        henchMan.IncreaseGroupByOne();
                    }
                }
                else if (warrior is IHero)
                {
                    IHero hero = warrior as IHero;

                    foreach (string skill in xmlWarrior.SkillList)
                    {
                        hero.AddSkill(skill);
                    }
                }
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