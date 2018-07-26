using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MordheimDal.XmlStorage
{
    [XmlRoot()]
    public class XmlHeadNode
    {
        public XmlHeadNode()
        {
            LastUpdate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [XmlAttribute]
        public string Version { get; set; } = "1.0.0";

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        [XmlAttribute]
        public DateTime LastUpdate { get; set; }

        [XmlElement]
        public XmlWarbandRoster WarbandRoster { get; set; } = new XmlWarbandRoster();

        //[XmlArray]
        //[XmlArrayItem(typeof(XmlCustomerModel))]
        //public List<XmlCustomerModel> CustomerList { get; set; }
    }
}