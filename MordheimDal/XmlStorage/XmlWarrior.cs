using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MordheimXmlDal.XmlStorage
{
    public class XmlWarrior
    {
        [XmlAttributeAttribute()]
        public string Name { get; set; }

        [XmlAttributeAttribute()]
        public string TypeOfWarrior { get; set; }
    }
}