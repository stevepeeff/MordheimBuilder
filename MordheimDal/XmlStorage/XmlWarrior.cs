using System.Collections.Generic;
using System.Xml.Serialization;

namespace MordheimXmlDal.XmlStorage
{
    public class XmlWarrior
    {
        [XmlAttributeAttribute()]
        public string Name { get; set; }

        [XmlAttributeAttribute()]
        public string TypeOfWarrior { get; set; }

        [XmlArray]
        [XmlArrayItem(typeof(string))]
        public List<string> EquipmentList { get; set; } = new List<string>();

        [XmlArray]
        [XmlArrayItem(typeof(string))]
        public List<string> MutationList { get; set; } = new List<string>();

        [XmlArray]
        [XmlArrayItem(typeof(string))]
        public List<string> SkillList { get; set; } = new List<string>();

        [XmlArray]
        [XmlArrayItem(typeof(string))]
        public List<string> SpellList { get; set; } = new List<string>();

        public int AmountInGroup { get; set; }
    }
}