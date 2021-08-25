using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TIADateiViewer
{
    public class node
    {
        [XmlAttribute]
        public string Type;

        public List<property> properties;
    }
}
