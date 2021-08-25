using System.Collections.Generic;
using System.Xml.Serialization;

namespace TIADateiViewer
{
    // Siehe https://docs.microsoft.com/en-us/dotnet/standard/serialization/examples-of-xml-serialization
    [XmlRoot("tiaselectiontool")]
    public class tiaselectiontool 
    {
        [XmlAttribute]
        public string Version;
        [XmlAttribute]
        public string Application;

        public business business;
        public application application;
    }
}
