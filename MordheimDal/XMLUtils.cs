using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MordheimDal
{
    /// <summary>
    /// Xml serialization and deserialization via stream and IFileSystem
    /// </summary>
    internal static class XMLUtils
    {
        private static readonly XmlIO _xmlIO = new XmlIO();

        /// <summary>
        /// Saves the file atomical by using Move operation, this ensures that the file is always written completely.
        /// Not supported by all filesystems such as FAT32, works on NTFS.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">Thrown when the object to serialize is null.</exception>
        /// <exception cref="XmlException">Thrown when the object could not be saved to Xml.</exception>
        public static void AtomicSave<T>(T objectToSerialize, string path) where T : class => _xmlIO.AtomicSave(objectToSerialize, path);

        /// <summary>
        /// Load a serialized object T from a file on harddisk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">string path to file</param>
        /// <returns>desirialized object T</returns>
        /// <exception cref="XmlException">Thrown when the stream could not be laoded.</exception>
        public static T Load<T>(string path) => (T)_xmlIO.Load(path, typeof(T));

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

        /// <summary>
        /// Save an object serialized to a file on the harddisk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">string path to store the serialized object T</param>
        /// <exception cref="ArgumentNullException">Thrown when the object to serialize is null.</exception>
        /// <exception cref="XmlException">Thrown when the object could not be saved to Xml.</exception>
        public static void Save<T>(T objectToSerialize, string path) where T : class => _xmlIO.Save(path, objectToSerialize);

        /// <summary>
        /// Validates the XML file.
        /// </summary>
        /// <param name="xmlFile">The XML file.</param>
        /// <param name="xsdFile">The XSD file.</param>
        /// <exception cref="XmlException">Thrown when XML to XSD validation fails</exception>
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
        /// Loads the specified object Stream.
        /// </summary>
        /// <param name="objectStream">The object Stream.</param>
        /// <param name="type">The type.</param>
        /// <returns>The deserailzied object from stream</returns>
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
                    throw new XmlException(XmlIO.XML_LOADING_FAILED_MESSAGE, ex);
                }
            }
            return default;
        }
    }
}