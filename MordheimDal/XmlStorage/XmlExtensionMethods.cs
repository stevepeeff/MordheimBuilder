using DomainModel;
using DomainModel.Equipment;
using DomainModel.Warbands;
using DomainModel.Warbands.BaseClasses;
using DomainModel.Warbands.CultOfThePossessed;
using MordheimXmlDal.XmlStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimDal.XmlStorage
{
    internal static class XmlExtensionMethods
    {
        public static XmlWarrior ToXml(this IWarrior warrior)
        {
            XmlWarrior xmlWarrior = new XmlWarrior()
            {
                TypeOfWarrior = warrior.TypeName,
                Name = warrior.Name
            };

            xmlWarrior.EquipmentList.AddRange(warrior.Equipment.Select(x => x.Name).ToList());

            if (warrior is IHenchMen)
            {
                IHenchMen henchMan = warrior as IHenchMen;
                xmlWarrior.AmountInGroup = henchMan.AmountInGroup;
            }
            else if (warrior is IHero)
            {
                IHero hero = warrior as IHero;
                xmlWarrior.SkillList.AddRange(hero.Skills.Select(x => x.SkillName).ToList());
            }
            if (warrior is IWizard)
            {
                IWizard wizard = warrior as IWizard;
                xmlWarrior.SpellList.AddRange(wizard.DrawnSpells.Select(x => x.SpellName).ToList());
            }
            if (warrior is IMutant)
            {
                IMutant mutant = warrior as IMutant;
                xmlWarrior.MutationList.AddRange(mutant.Mutations.Select(x => x.Name).ToList());
            }

            return xmlWarrior;
        }

        public static XmlHeadNode ToXml(this IWarbandRoster roster)
        {
            XmlHeadNode xmlHeadNode = new XmlHeadNode();
            xmlHeadNode.WarbandRoster.Name = roster.Name;
            xmlHeadNode.WarbandRoster.Warband = roster.WarBand.WarBandName;

            return xmlHeadNode;
        }

        public static IWarrior FromXml(this IWarbandRoster warbandRoster, XmlWarrior xmlWarrior)
        {
            IWarrior warrior = warbandRoster.WarBand.GetWarrior(xmlWarrior.TypeOfWarrior);

            warrior = warbandRoster.AddWarrior(warrior);
            warrior.Name = xmlWarrior.Name;
            foreach (string item in xmlWarrior.EquipmentList)
            {
                warrior.AddEquipment(item);
            }
            if (warrior is IHenchMen)
            {
                IHenchMen henchMan = warrior as IHenchMen;

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
            if (warrior is IWizard)
            {
                IWizard wizard = warrior as IWizard;

                foreach (string item in xmlWarrior.SpellList)
                {
                    wizard.AddSpell(item);
                }
            }
            if (warrior is IMutant)
            {
                IMutant mutant = warrior as IMutant;
                mutant.AddMutations(xmlWarrior.MutationList);
            }

            return warrior;
        }
    }
}