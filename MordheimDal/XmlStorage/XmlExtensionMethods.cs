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
            return new XmlWarrior()
            {
                TypeOfWarrior = warrior.TypeName,
                Name = warrior.Name
            };
        }
    }
}