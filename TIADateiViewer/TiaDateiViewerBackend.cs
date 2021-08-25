using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TIADateiViewer
{
    class TiaDateiViewerBackend : Backend
    {

        tiaselectiontool deserializedTiaFile { get; set; }

        public void openTiaFile(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(tiaselectiontool));
            var fileReader = new StreamReader(path);
            tiaselectiontool deserializedTiaFile = (tiaselectiontool)xmlSerializer.Deserialize(fileReader);
            fileReader.Close();
            this.deserializedTiaFile = deserializedTiaFile;
        }

        public bool isValidFileOpen()
        {
            return deserializedTiaFile != null;
        }

        public Dictionary<string, List<node>> getNodes()
        {
            if(!isValidFileOpen())
            {
                return null;
            }

            var nodeDict = new Dictionary<string, List<node>>();
            foreach(var node in deserializedTiaFile.business.graph.nodes)
            {
                if(nodeDict.ContainsKey(node.Type))
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
