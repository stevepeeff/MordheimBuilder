using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MordheimDal
{
    internal static class XMLUtils
    {
        #region Constants

        private const string XML_LOADING_FAILED_MESSAGE = "Failed to load the Xml object stream.";
        private const string XML_SAVING_FAILED_MESSAGE = "Failed to save object to Xml.";

        #endregion Constants

        /// <summary>
        /// Validates the XML file.
        /// </summary>
        /// <param name="xmlFile">The XML file.</param>
        /// <param name="xsdFile">The XSD file.</param>
        /// <exception cref="XmlException">Thrown when XML to XSD validation fails</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static void ValidateXmlFile(string xmlFile, string xsdFile)
        {
            try
            {
                var settings = new XmlReaderSettings()
                {
                    ValidationType = ValidationType.Schema,
                };
                settings.Schemas.Add(null, xsdFile);

                var document = new XmlDocument();
                document.Load(xmlFile);

                using (var xmlReader = XmlReader.Create(new StringReader(document.InnerXml), settings))
                {
                    while (xmlReader.Read()) { }
                }
            }
            catch (Exception ex)
            {
                throw new XmlException($"Failed to validate XML File: {xmlFile} to XSD file: {xsdFile}. Exception: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Save an object serialized to a file on the harddisk
        /// </summary>
        /// <param name="path">string path to store the serialized object</param>
        /// <param name="objectToSerialize">object to serialize</param>
        /// <exception cref="ArgumentNullException">Thrown when the object to serialize is null.</exception>
        /// <exception cref="XmlException">Thrown when the object could not be saved to Xml.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        private static void Save(string path, Object objectToSerialize)
        {
            if (objectToSerialize == null) { throw new ArgumentNullException("objectToSerialize"); }

            try
            {
                var type = objectToSerialize.GetType();
                var xmlserializer = new XmlSerializer(type);

                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, new XmlWriterSettings() { Indent = true }))
                    {
                        xmlserializer.Serialize(xmlWriter, objectToSerialize);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new XmlException(XML_SAVING_FAILED_MESSAGE, exception);
            }
        }

        /// <summary>
        /// Saves the file atomical by using Move operation, this ensures that the file is always written completely.
        /// Not supported by all filesystems such as FAT32, works on NTFS.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">Thrown when the object to serialize is null.</exception>
        /// <exception cref="XmlException">Thrown when the object could not be saved to Xml.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static void AtomicSave<T>(T objectToSerialize, string path) where T : class
        {
            string tempFileName = Path.GetTempFileName();
            Save(tempFileName, objectToSerialize);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Move(tempFileName, path); // atomic action on NTFS

            try
            {
                File.Delete(tempFileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to delete File: '{0}'. Exception {1}", tempFileName, ex.Message);
                /* failed deletion of temporary files can safely be ignored */
            }
        }

        /// <summary>
        /// Save an object serialized to a file on the harddisk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">string path to store the serialized object T</param>
        /// <exception cref="ArgumentNullException">Thrown when the object to serialize is null.</exception>
        /// <exception cref="XmlException">Thrown when the object could not be saved to Xml.</exception>
        public static void Save<T>(T objectToSerialize, string path) where T : class => Save(path, objectToSerialize);

        /// <summary>
        /// Load a serialized object from a file on harddisk
        /// </summary>
        /// <param name="path">string path to file</param>
        /// <param name="type">typeof object to desirialize</param>
        /// <returns>deserialized object</returns>
        /// <exception cref="XmlException">Thrown when loading the Xml file failed.</exception>
        private static object Load(string path, Type type)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (var filestream = new FileStream(path, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(type);
                        return serializer.Deserialize(filestream);
                    }
                }
                catch (Exception ex)
                {
                    throw new XmlException(XML_LOADING_FAILED_MESSAGE, ex);
                }
            }

            return default;
        }

        /// <summary>
        /// Loads the specified object Stream.
        /// </summary>
        /// <param name="objectStream">The object Stream.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="XmlException">Thrown when the stream could not be deserialized.</exception>
        private static object Load(Stream objectStream, Type type)
        {
            if (objectStream != null)
            {
                try
                {
                    var serializer = new XmlSerializer(type);
                    return serializer.Deserialize(objectStream);
                }
                catch (Exception ex)
                {
                    throw new XmlException(XML_LOADING_FAILED_MESSAGE, ex);
                }
            }
            return default;
        }

        /// <summary>
        /// Load a serialized object T from a file on harddisk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">string path to file</param>
        /// <returns>desirialized object T</returns>
        /// <exception cref="XmlException">Thrown when the stream could not be laoded.</exception>
        public static T Load<T>(string path) => (T)Load(path, typeof(T));

        /// <summary>
        /// Load a serialized object T from a file on harddisk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream">string path to file</param>
        /// <returns>
        /// desirialized object T
        /// </returns>
        /// <exception cref="XmlException">Thrown when the stream could not be loaded.</exception>
        public static T Load<T>(Stream stream) => (T)Load(stream, typeof(T));
    }
}