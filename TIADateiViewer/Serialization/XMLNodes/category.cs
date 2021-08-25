using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TIADateiViewer
{
    public class category
    {
        [XmlAttribute]
        public string Name;
        public List<element> elements;
    }
}
