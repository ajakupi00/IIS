using System.Xml.Serialization;
using System.Xml;

namespace IIS.Utils
{
    public static class ValidationUtils
    {
        public static T DeserializeXmlToObject<T>(XmlDocument xmlDoc)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDoc.DocumentElement))
            {
                if (xmlSerializer.CanDeserialize(xmlNodeReader))
                {
                    return (T)xmlSerializer.Deserialize(xmlNodeReader);
                }
            }
            return default(T);
        }
    }
}
