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

        public void assumeExampleValues()
        {
            Version = "2015.3.9.0";
            Application = "TIA Selection Tool";

            business = new business();
            application = new application();

            business.graph = new graph();
            business.graph.nodes = new List<node>();
            business.graph.nodes.Add(new node() { Type = "TYPENAME", properties = new List<property>() { new property() { key = "KKKK", value = "VVVVV" } } });

            application.contexts = new List<context>() { new context() { groups = new List<group>() { new group() { categories = new List<category>() { new category() { Name = "CATEGORYNAME", elements = new List<element>() { new element() { Name = "ELEMENTNAME" } } } } } } } };
        }

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
