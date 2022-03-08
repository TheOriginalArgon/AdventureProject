using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using AdventureProject.GameInstances;

namespace AdventureProject.GameEngine
{
    public static class Storage
    {
        private const string default_path = @"C:\temp";

        private static List<Adventure> storage_adventures = new List<Adventure>();
        private static List<Character> storage_characters = new List<Character>();

        public static void StoreData(Adventure data, string filename = "unnamed")
        {
            // Create the document.
            XmlDocument xmlDocument = new XmlDocument();

            // Create the body to store the object.
            XmlElement objType = xmlDocument.CreateElement(data.GetType().Name);
            xmlDocument.AppendChild(objType);

            XmlElement objName = xmlDocument.CreateElement(nameof(data.Name));
            XmlText objNameText = xmlDocument.CreateTextNode(data.Name);
            objName.AppendChild(objNameText);
            objType.AppendChild(objName);

            XmlElement objID = xmlDocument.CreateElement(nameof(data.ID));
            XmlText objIDText = xmlDocument.CreateTextNode(data.ID.ToString());
            objID.AppendChild(objIDText);
            objType.AppendChild(objID);

            XmlElement objCharacter = xmlDocument.CreateElement(nameof(data.MainCharacter));
            XmlText objCharacterText = xmlDocument.CreateTextNode(data.MainCharacter.FullName());
            objCharacter.AppendChild(objCharacterText);
            objType.AppendChild(objCharacter);


            xmlDocument.Save($@"{default_path}\{filename}.xml");
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            //try
            //{
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save($@"{default_path}\{fileName}.xml");
                }
            //}
            //catch (Exception ex)
            //{
                //Log exception here
            //}
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load($@"{default_path}\{fileName}.xml");
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }

    }
}
