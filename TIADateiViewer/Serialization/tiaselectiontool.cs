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

        public List<string> getNodeTypes()
        {
            var types = new List<string>();
            foreach(var node in business.graph.nodes)
            {
                types.Add(node.Type);
            }
            return types;
        }

        public node findNode(string typeName)
        {
            for(int i = 0; i<business.graph.nodes.Count; i++) {
                var node = business.graph.nodes[i];
                if(node.Type.ToUpper().Equals(node.Type.ToUpper()))
                {
                    return node;
                }
            }
            return null;
        }
    }
}
