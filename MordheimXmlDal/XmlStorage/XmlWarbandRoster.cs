using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MordheimXmlDal.XmlStorage
{
    public class XmlWarbandRoster
    {
        [XmlAttributeAttribute()]
        public string Name { get; set; }

        [XmlAttributeAttribute()]
        public string Warband { get; set; }

        [XmlArray]
        [XmlArrayItem(typeof(XmlWarrior))]
        public List<XmlWarrior> WarriorList { get; set; } = new List<XmlWarrior>();
    }
}