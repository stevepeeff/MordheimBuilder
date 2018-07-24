using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlDal.XmlModel
{
    [XmlRoot("XMLRootTestModel")]
    public class XmlHeadNodeModel
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [XmlAttribute]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>
        /// The last update.
        /// </value>
        [XmlAttribute]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the customer list.
        /// </summary>
        /// <value>
        /// The customer list.
        /// </value>
        [XmlArray]
        [XmlArrayItem(typeof(XmlCustomerModel))]
        public List<XmlCustomerModel> CustomerList { get; set; }

        public XmlHeadNodeModel()
        {
            CustomerList = new List<XmlCustomerModel>();
            Version = "1.0.0";
            LastUpdate = DateTime.Now;
        }
    }

    public class XmlCustomerModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        [XmlAttributeAttribute()]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlAttributeAttribute()]
        public String CustomerName { get; set; }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        [XmlElement]
        public List<XmlProjectModel> Projects { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlCustomerModel"/> class.
        /// </summary>
        public XmlCustomerModel()
        {
            Projects = new List<XmlProjectModel>();
        }
    }

    public class XmlProjectModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        [XmlAttributeAttribute()]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        /// <value>
        /// The name of the project.
        /// </value>
        [XmlAttributeAttribute()]
        public String ProjectName { get; set; }

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        [XmlElement]
        public List<XmlTaskModel> Tasks { get; set; }

        public XmlProjectModel()
        {
            Tasks = new List<XmlTaskModel>();
        }
    }

    public class XmlTaskModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        [XmlAttributeAttribute()]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        [XmlAttributeAttribute()]
        public String TaskName { get; set; }

        /// <summary>
        /// Gets the tracks.
        /// </summary>
        [XmlElement]
        public List<XmlTimeTrackModel> Tracks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlTaskModel"/> class.
        /// </summary>
        public XmlTaskModel()
        {
            Tracks = new List<XmlTimeTrackModel>();
        }
    }

    public class XmlTimeTrackModel
    {
        /// <summary>
        /// Gets the start time.
        /// </summary>
        [XmlAttributeAttribute()]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        [XmlAttributeAttribute()]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlTimeTrackModel"/> class.
        /// </summary>
        public XmlTimeTrackModel()
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }
    }
}