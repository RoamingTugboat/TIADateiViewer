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

        public List<string> getNodeTypes()
        {
            return deserializedTiaFile?.getNodeTypes();
        }

        public node findNode(string typeName)
        {
            return deserializedTiaFile?.findNode(typeName);
        }
    }
}
