using DomainModel.Equipment;
using DomainModel.Warbands;
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

            return xmlWarrior;
        }
    }
}