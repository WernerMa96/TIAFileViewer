using System.Xml;
using System.Xml.Serialization;

namespace TIAFileViewer.Helper
{
    /// <summary>
    /// Helper class for xml handling
    /// </summary>
    public static class XMLHelper
    {
        /// <summary>
        /// Deserialize xml to a object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (XmlReader reader = XmlReader.Create(path))
            {
                return (T)ser.Deserialize(reader);
            }
            
        }
    }
}
