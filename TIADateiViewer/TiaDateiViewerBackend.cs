using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TIADateiViewer
{
    class TiaDateiViewerBackend : Backend
    {

        tiaselectiontool deserializedTiaFile { get; set; }
        Dictionary<string, List<node>> NodeTypeDictionary { get; set; }
        

        public void openTiaFile(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(tiaselectiontool));
            var fileReader = new StreamReader(path);

            tiaselectiontool deserializedTiaFile = (tiaselectiontool)xmlSerializer.Deserialize(fileReader);
            fileReader.Close();
            this.deserializedTiaFile = deserializedTiaFile;
            NodeTypeDictionary = deserializedTiaFile.generateNodeDict();
        }

        public bool isValidFileOpen()
        {
            return deserializedTiaFile != null;
        }

        public Dictionary<string, List<node>> getTiaNodesDictionary()
        {
            return NodeTypeDictionary;
        }


    }
}
