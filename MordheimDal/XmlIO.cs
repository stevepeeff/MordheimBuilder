using System;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Xml;
using System.Xml.Serialization;

namespace MordheimDal
{
    internal class XmlIO
    {
        public const string XML_LOADING_FAILED_MESSAGE = "Failed to load the Xml object stream.";
        public const string XML_SAVING_FAILED_MESSAGE = "Failed to save object to Xml.";

        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlIO"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        public XmlIO(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlIO"/> class.
        /// </summary>
        public XmlIO() : this(new FileSystem())
        {
        }

        /// <summary>
        /// Atomics the save.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <param name="path">The path.</param>
        public void AtomicSave<T>(T objectToSerialize, string path) where T : class
        {
            string tempFileName = _fileSystem.Path.GetTempFileName();
            Save(tempFileName, objectToSerialize);

            if (_fileSystem.File.Exists(path))
            {
                _fileSystem.File.Delete(path);
            }
            _fileSystem.File.Move(tempFileName, path); // atomic action on NTFS

            try
            {
                _fileSystem.File.Delete(tempFileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to delete File: '{tempFileName}'. Exception {ex.Message}");
                /* failed deletion of temporary files can safely be ignored */
            }
        }

        /// <summary>
        /// Loads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.Xml.XmlException"></exception>
        public object Load(string path, Type type)
        {
            if (_fileSystem.File.Exists(path))
            {
                try
                {
                    using (var filestream = _fileSystem.FileStream.New(path, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(type);
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
        /// Save an object serialized to a file on the harddisk
        /// </summary>
        /// <param name="path">string path to store the serialized object</param>
        /// <param name="objectToSerialize">object to serialize</param>
        /// <exception cref="ArgumentNullException">Thrown when the object to serialize is null.</exception>
        /// <exception cref="XmlException">Thrown when the object could not be saved to Xml.</exception>
        public void Save(string path, Object objectToSerialize)
        {
            if (objectToSerialize == null) { throw new ArgumentNullException("objectToSerialize"); }

            try
            {
                var type = objectToSerialize.GetType();
                var xmlserializer = new XmlSerializer(type);

                using (var fileStream = _fileSystem.FileStream.New(path, FileMode.Create))
                {
                    using (var xmlWriter = XmlWriter.Create(fileStream, new XmlWriterSettings() { Indent = true }))
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
    }
}