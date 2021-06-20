using System.Xml.Serialization;

namespace TIAFileViewer.Model
{
    [XmlRoot("tiaselectiontool")]
    public class TiaSelectionTool
    {
        [XmlElement("business")]
        public Business[] Business { get; set; }
    }

    [XmlRoot("business")]
    public class Business
    {
        [XmlElement("graph")]
        public Graph[] Graph { get; set; }
    }

    [XmlRoot("graph")]
    public class Graph
    {
        [XmlElement("nodes")]
        public Nodes[] Nodes { get; set; }
    }

    [XmlRoot("nodes")]
    public class Nodes
    {
        [XmlElement("node")]
        public Node[] Node { get; set; }
    }

    [XmlRoot("node")]
    public class Node
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlElement("properties")]
        public Properties[] Properties { get; set; }
    }

    [XmlRoot("properties")]
    public class Properties
    {
        [XmlElement("property")]
        public Property[] Property { get; set; }
    }

    [XmlRoot("property")]
    public class Property
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }
}
