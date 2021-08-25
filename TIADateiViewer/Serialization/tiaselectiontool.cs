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

        public Dictionary<string, List<node>> generateNodeDict()
        {
            var nodeDict = new Dictionary<string, List<node>>();
            foreach (var node in business.graph.nodes)
            {
                if (nodeDict.ContainsKey(node.Type))
                {
                    nodeDict[node.Type].Add(node);
                }
                else
                {
                    nodeDict.Add(node.Type, new List<node>() { node });
                }
            }
            return nodeDict;
        }

    }
}
